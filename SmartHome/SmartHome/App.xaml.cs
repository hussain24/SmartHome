using MQTTnet.Client;
using MQTTnet;
using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Threading;
using SmartHome.Views;

namespace SmartHome
{
    public partial class App : Application
    {
        public static IMqttClient mqttClient;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            StartMQTT();
        }

        protected override void OnSleep()
        {
            StopMQTT();
        }

        protected override void OnResume()
        {
            StartMQTT();
        }

        public static async Task Connect_Client()
        {
            /*
             * This sample creates a simple MQTT client and connects to a public broker.
             *
             * Always dispose the client when it is no longer used.
             * The default version of MQTT is 3.1.1.
             */

            var mqttFactory = new MqttFactory();

            mqttClient = mqttFactory.CreateMqttClient();

            // Use builder classes where possible in this project.
            var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("broker.hivemq.com").Build();

            // This will throw an exception if the server is not available.
            // The result from this message returns additional data which was sent 
            // from the server. Please refer to the MQTT protocol specification for details.
            var response = await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
            Console.WriteLine("The MQTT client is connected.");

        }

        void StartMQTT()
        {
            Task.Run(async () => { 
                await Connect_Client();
            
            });
        }
        void StopMQTT()
        {
            Task.Run(async () =>
            {
                var mqttFactory = new MqttFactory();
                mqttClient = mqttFactory.CreateMqttClient();

                // Use builder classes where possible in this project.
                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("broker.hivemq.com").Build();
                // Send a clean disconnect to the server by calling _DisconnectAsync_. Without this the TCP connection
                // gets dropped and the server will handle this as a non clean disconnect (see MQTT spec for details).
                var mqttClientDisconnectOptions = mqttFactory.CreateClientDisconnectOptionsBuilder().Build();

                await mqttClient.DisconnectAsync(mqttClientDisconnectOptions, CancellationToken.None);
            });
        }

        public bool PublishMessage(string msg)
        {
            if (mqttClient.IsConnected)
            {
                var message = new MqttApplicationMessageBuilder()
            .WithTopic("hussainRoom")
            .WithPayload(msg)
            .WithRetainFlag()
            .Build();
                Task.Run(async () =>
                {
                    await mqttClient.PublishAsync(message, CancellationToken.None);
                });
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
