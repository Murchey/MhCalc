using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MhCalc
{
    public class variable
    {
        //strs 储存字符串的集合
        //ints 储存整数的集合
        //doubles 储存小数的集合
        //dicInt 储存整数的字典
        //dicDouble 储存小数的字典
        //dicStr 储存字符串的字典
        public static List<string> strs = new List<string>();
        public static List<int> ints = new List<int>();
        public static List<double> doubles = new List<double>();
        public static Dictionary<string, int> dicInt = new Dictionary<string, int>();
        public static Dictionary<string, double> dicDouble = new Dictionary<string, double>();
        public static Dictionary<string, string> dicStr = new Dictionary<string, string>();
        public static int SaveIntVariable(string variableName, int item)//储存整数
        {
            dicInt.Add(variableName, item);
            return item;//返回变量
        }
        public static double SaveDoubleVariable(string variableName,double item)//储存小数
        {
            dicDouble.Add(variableName,item);
            return item;//返回变量
        }
        public static string SaveStringVariable(string variableName, string item)//储存字符串
        {
            dicStr.Add(variableName, item);
            return item;//返回变量
        }
    }
}
