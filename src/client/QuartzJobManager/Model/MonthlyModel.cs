using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzJobManager.Model
{

    public class XFTemplateData
    {

        //public TemplateDataItem BirthDay { get; set; }
        //public TemplateDataItem ShopName { get; set; }
        public TemplateDataItem first { get; set; }
        public TemplateDataItem time { get; set; }
        public TemplateDataItem remark { get; set; }

        //public TemplateDataItem productType { get; set; }
        //public TemplateDataItem name { get; set; }
        //public TemplateDataItem accountType { get; set; }
        //public TemplateDataItem account { get; set; }
        //public TemplateDataItem time { get; set; }
        //public TemplateDataItem remark { get; set; }
    }
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
