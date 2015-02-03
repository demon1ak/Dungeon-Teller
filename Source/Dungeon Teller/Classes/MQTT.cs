using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Dungeon_Teller.Classes
{
    class MQTT
    {

        public static string realm;
        public static string name;

        public static void send(string message)
        {   
            MqttClient client = new MqttClient("broker.mqttdashboard.com",1883,false,null);

            client.Connect(Guid.NewGuid().ToString());

            string topic = String.Format("info/javadev/dungeonteller/char/{0}/{1}",realm,name);

            string[] topics = {topic};

            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE};
            client.Subscribe(topics,qosLevels);

            client.Publish(topics[0].ToLower(), Encoding.UTF8.GetBytes(message));

        }

    }
}
