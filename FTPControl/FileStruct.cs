using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTPControl
{
    class FileStruct
    {
        public DateTime CreateTime { get; set; }
        public Boolean IsDirectory { get; set; }
        public String Name { get; set; }
        public String Flags { get; set; }
        public String Owner { get; set; }
        public String Group { get; set; }
    }

    enum FileListStyle
    {
        UnixStyle=0,
        WindowsStyle,
        Unknown
    }

    public enum Operation
    {
        DownLoad,
        UpLoad,
        Delete
    }
}
