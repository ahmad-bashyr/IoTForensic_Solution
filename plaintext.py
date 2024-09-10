import paho.mqtt.client as mqtt
import time
import random

broker = "localhost" 
port = 1883 
access_token = "T1_TEST_TOKEN"  

topic = "v1/devices/me/telemetry"
def on_connect(client, userdata, flags, rc):
    print("Connected with result code "+str(rc))
def on_message(client, userdata, msg):
    print(msg.topic+" "+str(msg.payload))

client = mqtt.Client()
client.username_pw_set(access_token)
client.on_connect = on_connect
client.on_message = on_message
client.connect(broker, port, 60)
client.loop_start()

while True:
    temperature = 20 + (5 * random.random())  # Random temperature data
    payload = '{"temperature": ' + str(temperature) + '}'
    client.publish(topic, payload)
    print(f"Published: {payload}")
    time.sleep(5)  # Wait for 5 seconds before publishing again
 

 