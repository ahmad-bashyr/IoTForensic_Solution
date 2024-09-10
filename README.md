# IoTForensic_Solution
An Approach to Extract Sensor Data From IoT Devices For Forensic Analysis
IoT Forensic Solution
This repository contains the implementation of an IoT Forensic Solution that can extract, decrypt, and analyze data from IoT devices, specifically focusing on handling encrypted network traffic. The solution was developed as part of a research project to address key challenges in IoT forensics, such as the extraction of encrypted sensor data.

Project Overview:
The IoT Forensic Solution provides a modular framework designed to assist forensic investigators in gathering and analyzing encrypted data from IoT devices. The system is capable of handling a wide variety of IoT protocols and devices, ensuring flexibility and scalability for large-scale IoT environments.

The core functionality includes:

Data Collection: Capturing both encrypted and unencrypted data from IoT devices using standardized communication protocols.
Encryption Handling: Decrypting data encrypted with AES (Advanced Encryption Standard) in CFB (Cipher Feedback) mode.
Data Storage: Securely storing collected and decrypted data in a PostgreSQL database.
Data Analysis: Identifying patterns and anomalies in the collected data.
Reporting: Generating detailed reports for forensic analysis.
Files Included
encrypted_data.py: This script simulates an IoT device that generates encrypted temperature data and transmits it using MQTT. The data is encrypted using AES in CFB mode.
plaintext.py: This script simulates an IoT device that transmits unencrypted temperature data using MQTT.
IoT Forensic Solution Code: The core forensic solution implemented in C#, which collects encrypted data, decrypts it, and stores it in a PostgreSQL database.
Installation
Prerequisites
ThingsBoard: Install ThingsBoard as the IoT platform to simulate devices and capture data.
PostgreSQL: Install PostgreSQL for storing the collected forensic data.
MQTT Broker: Use Mosquitto or any MQTT broker to handle the data transmission between the IoT devices and ThingsBoard.

Clone the Repository:

git clone https://github.com/ahmad-bashyr/IoTForensic_Solution.git
cd IoTForensic_Solution
Running the Python Scripts
plaintext.py: Run this script to simulate IoT data transmission without encryption.


python plaintext.py
encrypted_data.py: Run this script to simulate IoT data transmission with AES encryption.

python encrypted_data.py
Running the IoT Forensic Solution
The IoT Forensic Solution is implemented as a C# console application. To run the solution:

Open the project in Visual Studio.
Build and run the solution.
The solution will automatically collect and decrypt data from the encrypted_data.py script and store the results in a PostgreSQL database.
Configurations
ThingsBoard Configuration: Configure virtual IoT devices in ThingsBoard to simulate the transmission of telemetry data.
Database Configuration: Ensure that PostgreSQL is installed and the database is correctly set up to store data collected by the forensic solution.
Features
Modular Architecture: The system is designed with modular components that handle data collection, encryption, storage, analysis, and reporting independently.
AES Decryption: Handles AES-encrypted IoT traffic, ensuring that secure data is accessible for forensic investigations.
Real-time Data Collection: The system captures data from IoT devices in real-time using the MQTT protocol.
Database Storage: Collected data, including metadata, is stored securely in a PostgreSQL database for later analysis.
