﻿using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Migraine_v2.LoginClass {
    public class Settings {
        public static JObject _Settings;
        public static string _Username;
        public static string _Password;
        public static string _Bitcoin;
        public static string _PayPal;
        public static string _Token;
       //public static string _RPC;

        public static void getSettings() {
            //-------------Create Settings.json file in dir-----------//
            if (!File.Exists("Settings.json"))
                File.AppendAllText("Settings.json", getDefaults());
                Thread.Sleep(200);
            //-------------------------------------------------------//
            try {
                string Unparsed = File.ReadAllText("Settings.json");
                _Settings = JObject.Parse(Unparsed);
                _Username = _Settings["userInfo"]["username"].ToString();
                _Password = _Settings["userInfo"]["password"].ToString();
                _Bitcoin  = _Settings["misc"]["bitcoin"].ToString();
                _PayPal   = _Settings["misc"]["paypal"].ToString();
                _Token    = _Settings["misc"]["token"].ToString();
                //_RPC = _Settings["misc"]["defaultRPC"].ToString();
            } catch {
                File.Delete("Settings.json");
                Thread.Sleep(200);
                getSettings();
            }
        }
        public static string getDefaults() {
            var str = new List<string>
            {
                "{",
                "\"userInfo\":{",
                "\"username\":\"\",",
                "\"password\":\"\"",
                "},",
                "\"misc\":{",
                "\"bitcoin\":\"\",",
                "\"paypal\":\"\",",
                "\"token\":\"\",",
                "}",
                "}"
            };
            return string.Join("\n", str.ToArray());
        }
    }
}
