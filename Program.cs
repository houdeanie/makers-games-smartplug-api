using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

namespace com.iqmeta.tplink_smartplug
{
    class Program
    {
        static void Main(string[] args)
        {
            //string bulbIP = "192.168.43.204";
            string plugOrSwitchIP = "192.168.43.204";
            try
            {

                while (true) {
                    //dynamic plugResponse = Utils.SendToSmartPlugOrSwitch(plugOrSwitchIP, Commands.SysInfoAndEmeter());
                    //Console.WriteLine(JsonConvert.SerializeObject(plugResponse, Formatting.Indented));
                    dynamic plugResponse = Utils.SendToSmartPlugOrSwitch(plugOrSwitchIP, Commands.Emeter());
                    string emeter = JsonConvert.SerializeObject(plugResponse, Formatting.Indented);
                    dynamic stuff = JsonConvert.DeserializeObject(emeter);
                    /*string pattern = "\\}.*\n.*\n.*\n.*\n.*\n.*\n.*\n.*";
                    string replacement = "";
                    Regex rgx = new Regex(pattern);
                    string result = rgx.Replace(emeter, replacement);
                    string pattern1 = "^\\{.*\n.*\n";
                    string replacement1 = "";
                    Regex rgx1 = new Regex(pattern1);
                    string result1 = rgx1.Replace(result, replacement1);
                    Console.WriteLine(result1);*/
                    string power = stuff.emeter.get_realtime.power_mw;
                    Console.WriteLine(power);

                }
                //Utils.SendToSmartPlugOrSwitch(plugOrSwitchIP, Commands.TurnOn());

                //Utils.SendToSmartPlugOrSwitch(plugOrSwitchIP, Commands.TurnOff());

                dynamic stats = Utils.SendToSmartPlugOrSwitch(plugOrSwitchIP, Commands.MonthStats(2016));
                Console.Write(JsonConvert.SerializeObject(stats, Formatting.Indented));

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadKey();
        }
    }
}
