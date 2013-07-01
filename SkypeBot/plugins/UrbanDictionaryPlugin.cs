using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Windows.Forms;
using SKYPE4COMLib;
using Procurios.Public;
using log4net;

namespace SkypeBot.plugins {
    public class UrbanDictionaryPlugin : Plugin {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public String name() { return "UrbanDictionary plugin"; }

        public String help() { return "!urban <word>"; }

        public String description() { return "Does UrbanDictionary lookups."; }

        public bool canConfig() { return false; }
        public void openConfig() { }

        public UrbanDictionaryPlugin() {
        }

        public void load() {
            log.Info("Plugin successfully loaded.");
        }

        public void unload() {
            log.Info("Plugin successfully unloaded.");
        }

        public void Skype_MessageStatus(IChatMessage message, TChatMessageStatus status) {
            Match output = Regex.Match(message.Body, @"^!urban (.*)", RegexOptions.IgnoreCase);
            if (output.Success) {
                String query = output.Groups[1].Value;
                
                WebRequest req = (HttpWebRequest) HttpWebRequest.Create("http://api.urbandictionary.com/v0/define?page=1&term=" + System.Uri.EscapeDataString(query));
                WebResponse resp;
                try {
                    resp = req.GetResponse();
                } catch (WebException) {
                    log.Warn("UrbanDictionary appears to be unavailable at the moment.");
                    message.Chat.SendMessage("Sorry, I seem to be unable to contact UrbanDictionary.");
                    return;
                }

                String responseText = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                var defs = (Hashtable) JSON.JsonDecode(responseText);

                if ((string)defs["response_type"] == "no_results") {
                    message.Chat.SendMessage(String.Format(@"UrbanDictionary lookup of ""{0}"": No results found.", query));
                } else {
                    var def = (defs["list"] as ArrayList)[0] as Hashtable;

                    message.Chat.SendMessage(String.Format(
                        "UrbanDictionary lookup of \"{0}\":\n\n{1}: {2}\n\n{3}",
                        query,
                        def["word"],
                        def["definition"],
                        def["example"]
                    ));
                }
            }
        }
    }
}
