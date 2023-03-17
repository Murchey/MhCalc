using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MhCalc
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 项目目标：制作一个简单的解释器
            // 基本原理说明：分割字符串


            #region 主体部分
            Console.Title = "MhCalc [1.0.0]";
            Console.WriteLine("MhCalc Beta_V1.0.0 [By Murchey]");//打印版权信息
            Console.WriteLine("显示帮助：/help");
            Console.WriteLine();
            do
            {

                Console.Write(">>>");//打印“>>>”
                string codeInput = Console.ReadLine();//codeInput是输入的内容
                if (string.IsNullOrEmpty(codeInput))//判断输入是否为空
                {
                    Console.WriteLine("error: null input");
                    continue;
                }
                else if (codeInput == "exit;")//输入exit;就退出
                {
                    break;
                }
                else
                {
                    //正常输入就传入解析函数
                    Console.WriteLine(ExplainCode(codeInput));
                }
            } while (true);
            #endregion
        }

        public static string ExplainCode(string codeInput)//把代码传到这个里面进行解释
        {
            char spliter = ' ';
            string[] codeWithoutBlank = codeInput.Split(spliter);//去除空格之后的代码
            switch (codeWithoutBlank[0])
            {
                case "int"://声明int变量
                    if (!(codeWithoutBlank[1].Contains(";")))
                    {
                        return ShowError(0);
                    }
                    else
                    {
                        return DeclearInt(codeWithoutBlank);
                    }
                case "double"://声明double变量
                    if (!(codeWithoutBlank[1].Contains(";")))
                    {
                        return ShowError(0);
                    }
                    else
                    {
                        return DeclearDouble(codeWithoutBlank);
                    }
                case "string":
                    if (!(codeInput.Substring(codeInput.Length - 1, 1) == ";"))
                    {
                        return ShowError(0);
                    }
                    else
                    {
                        return DeclearString(codeInput, codeWithoutBlank);
                    }
                case "compute"://变量计算
                    if (!(codeWithoutBlank[1].Contains(";")))
                    {
                        return ShowError(0);
                    }
                    else
                    {
                        return Compute(codeWithoutBlank).ToString();
                    }
                case "/help"://显示帮助
                    return ShowHelp();
                case "sqrt"://开方
                    if (!(codeWithoutBlank[1].Contains(";")))
                    {
                        return ShowError(0);
                    }
                    else
                    {
                        return Sqrt(codeWithoutBlank);
                    }
                case "pow"://乘方
                    if (!(codeWithoutBlank[1].Contains(";")))
                    {
                        return ShowError(0);
                    }
                    else
                    {
                        return Pow(codeWithoutBlank);
                    }
                case "sin"://sin
                    if (!(codeWithoutBlank[1].Contains(";")))
                    {
                        return ShowError(0);
                    }
                    else
                    {
                        return Sin(codeWithoutBlank);
                    }
                case "tan"://tan
                    if (!(codeWithoutBlank[1].Contains(";")))
                    {
                        return ShowError(0);
                    }
                    else
                    {
                        return Tan(codeWithoutBlank);
                    }
                case "cos"://cos
                    if (!(codeWithoutBlank[1].Contains(";")))
                    {
                        return ShowError(0);
                    }
                    else
                    {
                        return Cos(codeWithoutBlank);
                    }
                case "arccos"://arccos
                    if (!(codeWithoutBlank[1].Contains(";")))
                    {
                        return ShowError(0);
                    }
                    else
                    {
                        return arccos(codeWithoutBlank);
                    }
                case "arcsin"://arcsin
                    if (!(codeWithoutBlank[1].Contains(";")))
                    {
                        return ShowError(0);
                    }
                    else
                    {
                        return arcsin(codeWithoutBlank);
                    }
                case "arctan"://arctan
                    if (!(codeWithoutBlank[1].Contains(";")))
                    {
                        return ShowError(0);
                    }
                    else
                    {
                        return arctan(codeWithoutBlank);
                    }
                case "atr"://角度转弧度
                    if (!(codeWithoutBlank[1].Contains(";")))
                    {
                        return ShowError(0);
                    }
                    else
                    {
                        return "π=" + Math.PI + "\r\n" + AngleToRadian(Convert.ToDouble(codeWithoutBlank[1].Substring(0, codeWithoutBlank[1].Length - 2))).ToString();
                    }
                case "rta"://角度转弧度
                    if (!(codeWithoutBlank[1].Contains(";")))
                    {
                        return ShowError(0);
                    }
                    else
                    {
                        return "π=" + Math.PI + "\r\n" + RadianToAngle(Convert.ToDouble(codeWithoutBlank[1].Substring(0, codeWithoutBlank[1].Length - 2))).ToString();
                    }
                case "grf"://Gaussian rounding function高斯取整函数
                    if (!(codeWithoutBlank[1].Contains(";")))
                    {
                        return ShowError(0);
                    }
                    else
                    {
                        return grf(codeWithoutBlank);
                    }
                case "log"://一般对数
                    if (!(codeWithoutBlank[1].Contains(";")))
                    {
                        return ShowError(0);
                    }
                    else
                    {
                        return log(codeWithoutBlank);
                    }
                case "lg"://以10为底的对数
                    if (!(codeWithoutBlank[1].Contains(";")))
                    {
                        return ShowError(0);
                    }
                    else
                    {
                        return lg(codeWithoutBlank);
                    }
                case "ln"://以e为底的对数
                    if (!(codeWithoutBlank[1].Contains(";")))
                    {
                        return ShowError(0);
                    }
                    else
                    {
                        return ln(codeWithoutBlank);
                    }
                default:
                    break;
            }//switch
            if (variable.dicInt.ContainsKey(codeWithoutBlank[0]))
            {
                return variable.dicInt[codeWithoutBlank[0]].ToString();
            }//调用int变量
            else if (variable.dicDouble.ContainsKey(codeWithoutBlank[0]))
            {
                return variable.dicDouble[codeWithoutBlank[0]].ToString();
            }//调用double变量
            else if (variable.dicStr.ContainsKey(codeWithoutBlank[0]))
            {
                return variable.dicStr[codeWithoutBlank[0]].ToString();
            }//调用string变量
            switch (codeWithoutBlank[0])
            {
                default:
                    return ShowError(1);
            }//未知代码报错
        }//ExplainCode

        /// <summary>
        /// 进行常数计算
        /// </summary>
        /// <param name="codeWithoutBlank">处理后的代码数组</param>
        /// <returns></returns>
        public static string Compute(string[] codeWithoutBlank)
        {
           var result = new System.Data.DataTable().Compute(codeWithoutBlank[1].Substring(0, codeWithoutBlank[1].Length - 1), "");
           return result.ToString();
        }//变量间的计算
        /// <summary>
        /// 开方
        /// </summary>
        /// <param name="codeWithoutBlank">处理后的代码数组</param>
        /// <returns>string</returns>
        public static string Sqrt(string[] codeWithoutBlank)
        {
            return Math.Sqrt(Convert.ToDouble(codeWithoutBlank[1].Substring(0, codeWithoutBlank[1].Length - 1))).ToString();
        }
        /// <summary>
        /// 乘方
        /// </summary>
        /// <param name="codeWithoutBlank">处理后的字符串数组</param>
        /// <returns></returns>
        public static string Pow(string[] codeWithoutBlank)
        {
            // pow 2^8;
            // pow 2^0.9;
            // pow 2^-0.9;
            int posChengFangFu;//乘方符号的位置
            string strX = "0";
            string strY = "0";
            for (int i = 0; i <= codeWithoutBlank[1].Length; i++)
            {
                if (codeWithoutBlank[1][i] == '^')
                {
                    posChengFangFu = i;
                    strX = codeWithoutBlank[1].Substring(0, posChengFangFu);
                    strY = codeWithoutBlank[1].Substring(posChengFangFu+1,codeWithoutBlank[1].Length-2-posChengFangFu);
                    break;
                }
                else
                {
                    continue;
                }
            }
            double x = Convert.ToDouble(strX);//底数
            double y = Convert.ToDouble(strY); ;//指数
            return Math.Pow(x, y).ToString();
        }
        /// <summary>
        /// 计算Sin值
        /// </summary>
        /// <param name="codeWithoutBlank">处理后的代码数组</param>
        /// <returns></returns>
        public static string Sin(string[] codeWithoutBlank)
        {
            return "π=" + Math.PI + "\r\n" + Math.Sin(AngleToRadian(Convert.ToDouble(codeWithoutBlank[1].Substring(0, codeWithoutBlank[1].Length - 1)))).ToString();
        }
        /// <summary>
        /// 计算Cos值
        /// </summary>
        /// <param name="codeWithoutBlank">处理后的代码数组</param>
        /// <returns></returns>
        public static string Cos(string[] codeWithoutBlank)
        {
            return "π=" + Math.PI + "\r\n" + Math.Cos(AngleToRadian(Convert.ToDouble(codeWithoutBlank[1].Substring(0, codeWithoutBlank[1].Length - 1)))).ToString();
        }
        /// <summary>
        /// 计算Tan值
        /// </summary>
        /// <param name="codeWithoutBlank">处理后的代码数组</param>
        /// <returns></returns>
        public static string Tan(string[] codeWithoutBlank)
        {
            return "π=" + Math.PI + "\r\n" + Math.Tan(AngleToRadian(Convert.ToDouble(codeWithoutBlank[1].Substring(0, codeWithoutBlank[1].Length - 1)))).ToString();
        }
        /// <summary>
        /// 角度制转弧度制
        /// </summary>
        /// <param name="angle">角度值</param>
        /// <returns></returns>
        public static double AngleToRadian(double angle)
        {
            return angle * Math.PI / 180;
        }
        /// <summary>
        /// 弧度制转角度制
        /// </summary>
        /// <param name="radian">弧度值</param>
        /// <returns></returns>
        public static double RadianToAngle(double radian)
        {
            return radian * 180 / Math.PI;
        }
        /// <summary>
        /// 计算arccos值
        /// </summary>
        /// <param name="codeWithoutBlank">处理后的代码数组</param>
        /// <returns></returns>
        public static string arccos(string[] codeWithoutBlank)
        {
            return "π=" + Math.PI + "\r\n" + "弧度制：" +Math.Acos(AngleToRadian(Convert.ToDouble(codeWithoutBlank[1].Substring(0, codeWithoutBlank[1].Length - 1)))).ToString()+"\r\n角度制："+ RadianToAngle(Math.Acos(AngleToRadian(Convert.ToDouble(codeWithoutBlank[1].Substring(0, codeWithoutBlank[1].Length - 1))))).ToString();
        }
        /// <summary>
        /// 计算arcsin值
        /// </summary>
        /// <param name="codeWithoutBlank">处理后的代码数组</param>
        /// <returns></returns>
        public static string arcsin(string[] codeWithoutBlank)
        {
            return "π=" + Math.PI + "\r\n" + "弧度制：" + Math.Asin(AngleToRadian(Convert.ToDouble(codeWithoutBlank[1].Substring(0, codeWithoutBlank[1].Length - 1)))).ToString() + "\r\n角度制：" + RadianToAngle(Math.Asin(AngleToRadian(Convert.ToDouble(codeWithoutBlank[1].Substring(0, codeWithoutBlank[1].Length - 1))))).ToString();
        }
        /// <summary>
        /// 计算arctan值
        /// </summary>
        /// <param name="codeWithoutBlank">处理后的代码数组</param>
        /// <returns></returns>
        public static string arctan(string[] codeWithoutBlank)
        {
            return "π=" + Math.PI + "\r\n" + "弧度制：" + Math.Atan(AngleToRadian(Convert.ToDouble(codeWithoutBlank[1].Substring(0, codeWithoutBlank[1].Length - 1)))).ToString() + "\r\n角度制：" + RadianToAngle(Math.Atan(AngleToRadian(Convert.ToDouble(codeWithoutBlank[1].Substring(0, codeWithoutBlank[1].Length - 1))))).ToString();
        }
        /// <summary>
        /// Gaussian rounding function高斯取整函数
        /// </summary>
        /// <param name="codeWithoutBlank">处理后的代码数组</param>
        /// <returns></returns>
        public static string grf(string[] codeWithoutBlank)
        {
            return Math.Ceiling(Convert.ToDouble(codeWithoutBlank[1].Substring(0, codeWithoutBlank[1].Length - 1))-1).ToString();
        }
        /// <summary>
        /// 一般对数运算
        /// </summary>
        /// <param name="codeWithoutBlank">处理后的字符串数组</param>
        /// <returns></returns>
        public static string log(string[] codeWithoutBlank)
        {
            double DiShu=1;//底数
            double ZhenShu=1;//真数
            for (int i = 0; i <= codeWithoutBlank[1].Length; i++)
            {
                if (codeWithoutBlank[1][i]=='_')
                {//1_1;
                    DiShu = Convert.ToDouble(codeWithoutBlank[1].Substring(0,i));
                    ZhenShu = Convert.ToDouble(codeWithoutBlank[1].Substring(i + 1, codeWithoutBlank[1].Length - 2 - i));
                    break;
                }
                else
                {
                    continue;
                }
            }
            return Math.Log(DiShu,ZhenShu).ToString();
        }
        /// <summary>
        /// 以十为底的对数运算
        /// </summary>
        /// <param name="codeWithoutBlank"></param>
        /// <returns></returns>
        public static string lg(string[] codeWithoutBlank)
        {
            return Math.Log10(Convert.ToDouble(codeWithoutBlank[1].Substring(0, codeWithoutBlank[1].Length - 1))).ToString();
        }
        /// <summary>
        /// 以自然常数为底的对数运算
        /// </summary>
        /// <param name="codeWithoutBlank"></param>
        /// <returns></returns>
        public static string ln(string[] codeWithoutBlank)
        {
            return "e="+Math.E+"\r\n"+Math.Log(Convert.ToDouble(codeWithoutBlank[1].Substring(0, codeWithoutBlank[1].Length - 1))).ToString();
        }

        
        /// <summary>
        /// 声明一个整数类型变量
        /// </summary>
        /// <param name="codeWithoutBlank">输入的代码字符串数组</param>
        /// <returns></returns>
        public static string DeclearInt(string[] codeWithoutBlank)
        {
            try
            {
                string variableName = GetvariableName(codeWithoutBlank);
                string variableValue = GetvariableValue(codeWithoutBlank);
                variable.SaveIntVariable(variableName, Convert.ToInt32(variableValue));
                return variableName + "=" + variableValue;
            }
            catch
            {
                string variableName = GetvariableName(codeWithoutBlank);
                string variableValue = GetvariableValue(codeWithoutBlank);
                variable.dicInt.Remove(variableName);//移除原始值并添加新值
                variable.SaveIntVariable(variableName, Convert.ToInt32(variableValue));
                return variableName + "=" + variableValue + "\r\n" + "已覆盖原始值";
            }
        }//声明一个整数变量
        /// <summary>
        /// 声明一个小数类型变量
        /// </summary>
        /// <param name="codeWithoutBlank">输入的代码字符串数组</param>
        /// <returns></returns>
        public static string DeclearDouble(string[] codeWithoutBlank)
        {
            try
            {
                string variableName = GetvariableName(codeWithoutBlank);
                string variableValue = GetvariableValue(codeWithoutBlank);
                variable.SaveDoubleVariable(variableName, Convert.ToDouble(variableValue));
                return variableName + "=" + variableValue;
            }
            catch
            {
                string variableName = GetvariableName(codeWithoutBlank);
                string variableValue = GetvariableValue(codeWithoutBlank);
                variable.dicDouble.Remove(variableName);//移除原始值并添加新值
                variable.SaveDoubleVariable(variableName, Convert.ToInt32(variableValue));
                return variableName + "=" + variableValue + "\r\n" + "已覆盖原始值";
            }
        }//声明一个小数变量
        /// <summary>
        /// 声明一个字符串类型变量
        /// </summary>
        /// <param name="codeInput">完整的代码字符串</param>
        /// <param name="codeWithoutBlank">处理后的代码数组</param>
        /// <returns></returns>
        public static string DeclearString(string codeInput, string[] codeWithoutBlank)
        {
            try
            {
                string variableName = GetvariableName(codeWithoutBlank);
                string variableValue = GetStringvariableValue(codeInput);
                variable.SaveStringVariable(variableName, variableValue);
                return variableName + "=" + variableValue;
            }
            catch
            {
                string variableName = GetvariableName(codeWithoutBlank);
                string variableValue = GetStringvariableValue(codeInput);
                variable.dicStr.Remove(variableName);//移除原始值并添加新值
                variable.SaveStringVariable(variableName, variableValue);
                return variableName + "=" + variableValue + "\r\n" + "已覆盖原始值";
            }
        }//声明一个字符串变量
        /// <summary>
        /// 显示帮助
        /// </summary>
        /// <returns>string</returns>
        public static string ShowHelp()
        {
            return "内置函数说明：\r\n" +
            "0.显示帮助： /help\r\n" +
            "1.退出： exit;\r\n" +
            "2.声明整数类型： int a=000;\r\n" +
            "3.声明小数类型： double d=0.99;\r\n" +
            "4.声明字符串变量： string str=\"555hello lll\";\r\n" +
            "5.调用变量： 变量名\r\n" +
            "6.数字间的计算： c 1*3+5-7/9;\r\n" +
            "[注释：目前未添加变量间的计算功能]\r\n" +
            "7.覆盖变量： 变量类型 变量名=新值;\r\n" +
            "8.计算乘方： pow 底数^指数;\r\n" +
            "9.计算开方： sqrt 根号下的数;\r\n" +
            "10.计算三角函数：sin/cos/tan 角度;\r\n" +
            "11.返回指定余弦值的度数：arccos 指定的值;\r\n" +
            "12.返回指定正弦值的度数：arcsin 指定的值;\r\n" +
            "13.返回指定正切值的度数：arctan 指定的值;\r\n" +
            "14.角度制转弧度制：atr 角度;\r\n" +
            "15.弧度制转角度制：rta 弧度;\r\n" +
            "16.高斯取整函数(Gaussian rounding function)：grf 十进制数;(注释：不大于该数的最大整数)\r\n";
        }//显示帮助
        /// <summary>
        /// 判断字符串里是否有字母
        /// </summary>
        /// <param name="text">要判断的字符串</param>
        /// <returns></returns>
        public static bool LettersExistsOrNot(string text)
        {
            foreach (char tempchar in text.ToCharArray())
            {
                if (!char.IsLetter(tempchar))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 报错方法
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        /// <returns>string</returns>
        public static string ShowError(int errorCode)
        {
            switch (errorCode)
            {
                case 0://结尾不带分号
                    return "error: unable to read the code without ';'";
                case 1://未知的代码
                    return "error: unknown code";
                case 2://计算时出错
                    return "error: unable to comput";
                default:
                    return "error: error[unknown errorCode]";
            }
        }
        /// <summary>
        /// 得变量名
        /// </summary>
        /// <param name="codeWithoutBlank">输入的代码字符串数组</param>
        /// <returns></returns>
        public static string GetvariableName(string[] codeWithoutBlank)
        {
            string strCodeWithoutBlank = codeWithoutBlank[1].ToString();
            string strvariableName = null;
            for (int i = 0; i <= strCodeWithoutBlank.Length; i++)
            {
                if (strCodeWithoutBlank[i] == '=')
                {
                    strvariableName = strCodeWithoutBlank.Substring(0, i);
                    break;
                }
                else
                {
                    continue;
                }
            }
            return strvariableName;
        }//得变量名
        /// <summary>
        /// 得变量值
        /// </summary>
        /// <param name="codeWithoutBlank">输入的代码字符串数组</param>
        /// <returns></returns>
        public static string GetvariableValue(string[] codeWithoutBlank)
        {
            string strCodeWithoutBlank = codeWithoutBlank[1].ToString();
            string strvariableValue = null;
            for (int i = 0; i <= strCodeWithoutBlank.Length; i++)
            {
                if (strCodeWithoutBlank[i] == '=')
                {
                    strvariableValue = strCodeWithoutBlank.Substring(i + 1);
                    strvariableValue = strvariableValue.Substring(0, strvariableValue.Length - 1);//删除末尾的分号
                    break;
                }
                else
                {
                    continue;
                }
            }
            return strvariableValue;
        }//得变量值
        /// <summary>
        /// 得字符串类型变量值
        /// </summary>
        /// <param name="codeInput">输入的完整代码</param>
        /// <returns></returns>
        public static string GetStringvariableValue(string codeInput)
        {
            string strvariableValue = null;
            for (int i = 0; i <= codeInput.Length; i++)
            {
                if (codeInput[i] == '=' && codeInput[i + 1] == '\"')
                {
                    //0123456789 10 11 12 13 14 15 16 17 18 
                    //string str =  "  h  e  l  l  o  "  ;
                    strvariableValue = codeInput.Substring(i + 2, codeInput.Length - i - 4);//删除末尾的分号
                    break;
                }
                else
                {
                    continue;
                }
            }
            return strvariableValue;
        }//得字符串变量值
    }
}