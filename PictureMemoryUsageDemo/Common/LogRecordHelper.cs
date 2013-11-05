using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PictureMemoryUsageDemo.EntityModels;

namespace PictureMemoryUsageDemo.Common
{
    public class LogRecordHelper
    {
        public static List<LogRecordInfo> _allLogRecordInfo = new List<LogRecordInfo>();

        public static void AddLogRecord(string status,string memoryUseage)
        {
            _allLogRecordInfo.Add(new LogRecordInfo() { Status = status, MemeoryUseage = memoryUseage, CreateDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff") });
        }

        public static void ClearLogRecord()
        {
            if (_allLogRecordInfo != null)
                _allLogRecordInfo.Clear();
        }
     
    }
}
