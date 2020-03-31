using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace 局域网IP扫描实验
{
    class Helps
    {
        #region  判断IP地址格式是否正确

        /// <summary>
                /// 判断ip地址是否正确，正确返回true 错误false
                /// </summary>
                /// <param name="strLocalIP">需要判断的字符串(IP地址)</param>
                /// <returns>TRUE OR FALSE</returns>
        public static bool IsRightIP(string strLocalIP)
        {
            bool bFlag = false;
            bool Result = true;


            Regex regex = new Regex("^[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}$");
            bFlag = regex.IsMatch(strLocalIP);
            if (bFlag == true)
            {
                string[] strTemp = strLocalIP.Split(new char[] { '.' });
                int nDotCount = strTemp.Length - 1; //字符串中.的数量，若.的数量小于3，则是非法的ip地址
                if (3 == nDotCount)//判断 .的数量
                {
                    for (int i = 0; i < strTemp.Length; i++)
                    {
                        if (Convert.ToInt32(strTemp[i]) > 255)   //大于255不符合返回false
                        {
                            Result = false;
                        }
                    }
                }
                else
                {
                    Result = false;
                }
            }
            else
            {
                //输入非数字则提示，不符合IP格式
                //MessageBox.Show("不符合IP格式");
                Result = false;
            }
            return Result;
        }
        #endregion
    }
}
