using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{

    public class TemplateData
    {
        public TemplateDataItem first { get; set; }
        public TemplateDataItem time { get; set; }
        public TemplateDataItem ip_list { get; set; }
        public TemplateDataItem sec_type { get; set; }
        public TemplateDataItem remark { get; set; }
    }
    public class XFTemplateData
    {
        public TemplateDataItem hymc { get; set; }
        public TemplateDataItem sj { get; set; }
        public TemplateDataItem bcxfje { get; set; }
        public TemplateDataItem xfje { get; set; }
        public TemplateDataItem dqje { get; set; }
        public TemplateDataItem time { get; set; }
    }

    /// <summary>
    /// 模板消息的数据项类型
    /// </summary>
    public class TemplateDataItem
    {
        /// <summary>
        /// 项目值
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 16进制颜色代码，如：#FF0000
        /// </summary>
        public string color { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v">value</param>
        /// <param name="c">color</param>
        public TemplateDataItem(string v, string c = "#173177")
        {
            value = v;
            color = c;
        }
    }
}
