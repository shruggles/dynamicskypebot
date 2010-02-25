﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SKYPE4COMLib;

namespace SkypeBot {
    public partial class SkypeChatPicker : Form {
        public String selectedChat;
        private List<String> chats;

        public SkypeChatPicker(Skype skype) {
            InitializeComponent();

            chats = new List<String>();

            chatList.Items.Clear();
            foreach (Chat chat in skype.Chats) {
                chats.Add(chat.Name);
                chatList.Items.Add(chat.FriendlyName);
            }
        }

        private void okBtn_Click(object sender, EventArgs e) {
            selectedChat = chats[chatList.SelectedIndex];
        }

        private void chatList_SelectedIndexChanged(object sender, EventArgs e) {
            okBtn.Enabled = (chatList.SelectedIndex > -1);
        }

    }
}
