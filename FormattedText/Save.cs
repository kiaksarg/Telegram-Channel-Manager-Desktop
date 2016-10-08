using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormattedText
{
    class Save
    {
        public string Token { get; set; }
        public string ChannelId { get; set; }
        public string Content { get; set; }
        public string Caption { get; set; }
        public string SelectedFile { get; set; }
        public string AudioTitle { get; set; }
        public string AudioPerformer { get; set; }
        public byte SendFileMethod { get; set; }
        public byte ParseMode { get; set; }
        public bool IsSilent { get; set; }
        public bool SendFileIsSilent { get; set; }
        public List<UrlButton> UrlButtons { get; set; }
        public string UrlButtonText { get; set; }
        public string UrlButtonURL { get; set; }
        public string Column { get; set; }
        public bool SendUrlButton { get; set; }

    }
}
