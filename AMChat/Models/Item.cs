using System;

namespace AMChat
{
    public class Item
    {
        public string Id { get; set; }
        public string ChatText { get; set; }
        public string ChatUserImage { get; set; }
        public string IsChatViewer { get; set; }

        public string ChatViewer => IsChatViewer.Equals("true") ? ChatUserImage : null;
        public string ContraChatViewer => IsChatViewer.Equals("false") ? ChatUserImage : null;

    }
}
