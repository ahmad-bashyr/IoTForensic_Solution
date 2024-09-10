import paho.mqtt.client as mqtt
import time
import random
from Cryptodome.Cipher import AES
import base64
import json

broker = "localhost"  
port = 1883  
access_token = "T1_TEST_TOKEN"

topic = "v1/devices/me/telemetry"
key = b'16ByteSecretKey!' 
def on_connect(client, userdata, flags, rc):
    print("Connected with result code " + str(rc))

def on_message(client, userdata, msg):
    print(msg.topic + " " + str(msg.payload))

client = mqtt.Client()
client.username_pw_set(access_token)

client.on_connect = on_connect
client.on_message = on_message
client.connect(broker, port, 60)
client.loop_start()

def encrypt_data(data):
    cipher = AES.new(key, AES.MODE_CFB)
    iv = cipher.iv
    ciphertext = cipher.encrypt(data.encode('utf-8'))
    encoded_data = {
        'iv': base64.b64encode(iv).decode('utf-8'),
        'ciphertext': base64.b64encode(ciphertext).decode('utf-8')
    }
    return json.dumps(encoded_data)
while True:
    temperature = 20 + (5 * random.random())
    payload = '{"temperature": ' + str(temperature) + '}'
    encrypted_payload = encrypt_data(payload)
    

    print(f"Encrypted Payload (Ciphertext): {encrypted_payload}")
    

    client.publish(topic, encrypted_payload)
    

    with open("encrypted_data.json", "w") as f:
        f.write(encrypted_payload)

    print("Encrypted data written to file: encrypted_data.json")
    
    time.sleep(5) 

