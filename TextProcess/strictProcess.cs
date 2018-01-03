using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.InteropServices;
using System.Data;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;



namespace TextProcess
{
    class strictProcess
    {
        //WordDic[] worddicArray = { };
        //全局变量
        List<String> resultList = new List<String>();   //接收最后结果

        #region 段间排比句
        public List<String> outStrictMatch(string allTxt)
        {

            /*
             * 先过滤有特殊符号的句子，从数据
             */

            String[] perSession = allTxt.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int[] temp = new int[perSession.Length * 2];
            int a = 0;
            temp[0] = -1;
            for (int m = 0; m < perSession.Length - 1; m++)
            {
                string filterPath = "..\\..\\filtertext.txt";
                FileStream fs = File.OpenRead(filterPath);
                StreamReader read = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
                string filtertext = read.ReadToEnd();
                string[] filterArray = filtertext.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                int n = 0;
                for (int i = 0; i < filterArray.Length; i++)
                {
                    if (perSession[m].Contains(filterArray[i]))
                    {
                        n++;
                        continue;
                    }
                }
                if (n == 0)
                {
                    if (m == 0)
                    {
                        continue;
                    }
                    for (int j = 0; j < a; j++)
                    {
                        if (m == temp[j])
                            m++;
                    }
                    perSession[m].Trim();
                    string[] word1 = perSession[m].Split(new string[] { "。" }, StringSplitOptions.RemoveEmptyEntries);
                    string words1 = word1[0].Trim();
                    for (int k = m + 1; k < perSession.Length; k++)
                    {
                        string[] word2 = perSession[k].Split(new string[] { "。" }, StringSplitOptions.RemoveEmptyEntries);
                        string words2 = word2[0].Trim();
                        if (words1.Length == words2.Length)
                        {
                            int mark = markMatch(words1, words2);
                            if (mark == 1)
                            {
                                if (NLPIR.Init(@"F:/Project/Visual Studio 2012/Projects/TextProcess/TextProcess/", 0))
                                {
                                    int s1count = NLPIR.getcount(words1);
                                    int s2count = NLPIR.getcount(words2);
                                    string s1 = NLPIR.ParagraphProcess(words1, true);
                                    string s2 = NLPIR.ParagraphProcess(words2, true);
                                    String[] splitDic1 = s1.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                                    String[] splitDic2 = s2.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                                    if (s1count >= s2count - 2 && s1count <= s2count + 2)
                                    {
                                        if (resultList.Contains(words1))
                                        {
                                            if (resultList.Contains(words2))
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                int index = resultList.IndexOf(words1);
                                                while (resultList[index + 1] != "")
                                                {
                                                    index++;
                                                }
                                                resultList.Insert(index + 1, words2);
                                            }
                                        }
                                        else
                                        {
                                            resultList.Add(words1);
                                            resultList.Add(words2);
                                            resultList.Add("");
                                        }
                                        temp[a] = k;
                                        a++;
                                    }


                                }
                            }

                        }
                        else if (NLPIR.Init(@"F:/Project/Visual Studio 2012/Projects/TextProcess/TextProcess/", 0))
                        {
                            int s1count = NLPIR.getcount(words1);
                            int s2count = NLPIR.getcount(words2);
                            string s1 = NLPIR.ParagraphProcess(words1, true);
                            string s2 = NLPIR.ParagraphProcess(words2, true);
                            String[] splitDic1 = s1.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            String[] splitDic2 = s2.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            if (s1count >= s2count - 1 && s1count <= s2count + 1)
                            {
                                int mark = markMatch(words1, words2);
                                if (mark == 1)
                                {
                                    if (resultList.Contains(words1))
                                    {
                                        if (resultList.Contains(words2))
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            int index = resultList.IndexOf(words1);
                                            while (resultList[index + 1] != "")
                                            {
                                                index++;
                                            }
                                            resultList.Insert(index + 1, words2);
                                        }
                                    }
                                    else
                                    {
                                        resultList.Add(words1);
                                        resultList.Add(words2);
                                        resultList.Add("");
                                    }
                                    temp[a] = k;
                                    a++;
                                }

                            }
                        }
                    }
                } 
            }
            return resultList;
        }
        #endregion

        #region 综合段内
        public List<String> allin(string allTxt)
        {
            String[] perSession = allTxt.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int m = 0; m < perSession.Length; m++)
            {
                string[] perSetence = perSession[m].Split(new string[] { "。", "？" }, StringSplitOptions.RemoveEmptyEntries);
                //找出含“；”的句子
                for (int j = 0; j < perSetence.Length; j++)
                {
                    string s=perSetence[j].ToString()[0].ToString();
                    if (perSetence[j].ToString()[0].ToString().Equals("”"))
                    {
                        perSetence[j]=perSetence[j].ToString().Substring(1);
                    }
                    if (perSetence[j].Contains("；"))
                    {
                        int index=perSetence[j].IndexOf("；");

                        if (index + 1 < perSetence[j].Length)
                        {
                            string substring = perSetence[j].Substring(index-8,17);
                            if (!substring.Contains("“") && !substring.Contains("”"))
                            {
                                string[] splitSte = perSetence[j].Split('；');
                                string result="";
                                for (int i = 0; i < splitSte.Length; i++)
                                {
                                    result += splitSte[i] + "； ";
                                }
                                resultList.Add(result);
                                resultList.Add("");
                            }
                            continue;
                        }
                        
                    }
                    //找出引用型排比
                    if (perSetence[j].Contains("“"))
                    {
                        if (perSetence[j].Contains("一点又一点"))
                        {
                            string ss = "";
                        }
                        
                        if (perSetence[j].Contains("”"))
                        {
                            for (int i = 0; i < perSetence[j].Length; i++)
                            {
                                if (perSetence[j][i].ToString().Equals("“"))
                                {
                                    if (i - 1 >= 0)
                                    {
                                        //if (!perSetence[j][i - 1].ToString().Equals("："))
                                        //{
                                            int w = i + 1;
                                            for (int p = i + 1; p < perSetence[j].Length; p++)
                                            {
                                                if (perSetence[j][p].ToString().Equals("”"))
                                                {
                                                    int v = p - 1;
                                                    string citestr = perSetence[j].ToString().Substring(w, v - w + 1);
                                                    if (!resultList.Contains(citestr))
                                                    {
                                                        if (citestr.Contains("，") || citestr.Contains("。") || citestr.Contains("、"))
                                                        {
                                                            resultList.Add(citestr);
                                                            resultList.Add("");
                                                           
                                                        }
                                                    }
                                                    break;
                                                }
                                            }
                                        //}
                                    }
                                    
                                    
                                }
                            }
                            
                        }
                        else
                        {
                            int index = perSetence[j].IndexOf("“");
                            if (index - 1 >= 0)
                            {
                                //if (!perSetence[j][index - 1].ToString().Equals("："))
                                //{
                                    int w = perSetence[j].IndexOf("“") + 1;
                                    int v = perSetence[j].Length - 1;
                                    string citestr = perSetence[j].ToString().Substring(w, v - w + 1);
                                    if (!resultList.Contains(citestr))
                                    {
                                        if (citestr.Contains("，"))
                                        {
                                            resultList.Add(citestr);
                                            resultList.Add("");
                                        }
                                    }
                                //}
                            }
                            else
                            {
                                int w = perSetence[j].IndexOf("“") + 1;
                                int v = perSetence[j].Length - 1;
                                string citestr = perSetence[j].ToString().Substring(w, v - w + 1);
                                if (!resultList.Contains(citestr))
                                {
                                    if (citestr.Contains("，"))
                                    {
                                        resultList.Add(citestr);
                                        resultList.Add("");
                                    }
                                }
                            }
                        }
                    }
                    //找出“，”排比
                    if (perSetence[j].Contains('，') || perSetence[j].Contains('！') || perSetence[j].Contains('：'))
                    {
                        closeMatch1(perSetence[j]);
                    }
                    else
                    {
                        if (j == 0)
                        {
                            continue;
                        }
                        //找出“。”排比
                        setenceMatch( perSetence[j - 1],perSetence[j]);
                    }
                    
                }
            }
            return resultList;
        }

        #endregion

        #region 相邻两句字数相同  用“，”
        public List<String> closeMatch1(String perSetence)
        {
            string filterPath = "..\\..\\filtertext.txt";
            FileStream fs = File.OpenRead(filterPath);
            StreamReader read = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
            string filtertext = read.ReadToEnd();
            string[] filterArray = filtertext.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);


            String[] everysetenceArray = perSetence.Split(new char[] { '，', '：', '！' }, StringSplitOptions.RemoveEmptyEntries);
            for (int p = 0; p < everysetenceArray.Length; p++)
            {
                if (everysetenceArray[p].Equals("亚洲基础设施投资银行已经为“一带一路”建设参与国的9个项目提供17亿美元贷款"))
                {
                    string sb = "";
                }
                if (p == 0)
                {
                    continue;
                }

                int count = 0;
                int count1 = 0;
                for (int i = 0; i < filterArray.Length; i++)
                {
                    if (everysetenceArray[p].Contains(filterArray[i]))
                    {
                        count++;
                        continue;

                    }
                }
                for (int i = 0; i < filterArray.Length; i++)
                {
                    if (everysetenceArray[p - 1].Contains(filterArray[i]))
                    {
                        count1++;
                        continue;

                    }
                }
                if (count == 0 && count1 == 0)
                {
                    string words2 = everysetenceArray[p].ToString();
                    words2 = words2.Trim();
                    string words1 = everysetenceArray[p - 1].ToString();
                    words1 = words1.Trim();

                    int mark = markMatch(words1, words2);
                    if (mark == 1)
                    {
                        if (words1.Length == words2.Length)
                        {
                            int bothDic = bothDicMatch1(words1, words2);
                            if (bothDic >= 1)
                            {
                                if (resultList.Contains(words1))
                                {
                                    int index = resultList.IndexOf(words1);
                                    while (resultList[index + 1] != "")
                                    {
                                        index++;
                                    }
                                    resultList.Insert(index + 1, words2);
                                }
                                else
                                {
                                    resultList.Add(words1);
                                    resultList.Add(words2);
                                    resultList.Add("");
                                }
                            }
                            else
                            {
                                if (NLPIR.getcount(words1) >= NLPIR.getcount(words2) - 2 && NLPIR.getcount(words1) <= NLPIR.getcount(words2) + 2)
                                {
                                    if (Math.Min(words1.Length, words2.Length) <= 4)
                                    {
                                        if (resultList.Contains(words1))
                                        {
                                            int index = resultList.IndexOf(words1);
                                            while (resultList[index + 1] != "")
                                            {
                                                index++;
                                            }
                                            resultList.Insert(index + 1, words2);
                                        }
                                        else
                                        {
                                            resultList.Add(words1);
                                            resultList.Add(words2);
                                            resultList.Add("");
                                        }
                                    }
                                    else
                                    {
                                        string s1 = NLPIR.ParagraphProcess(words1, true);
                                        string s2 = NLPIR.ParagraphProcess(words2, true);
                                        String[] splitDic1 = s1.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                                        String[] splitDic2 = s2.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                                        int count2 = 0;
                                        for (int q = 0; q < Math.Min(splitDic1.Length, splitDic2.Length); q++)
                                        {
                                            if (splitDic1[q] != "" && splitDic2[q] != "")
                                            {
                                                string[] everysplitDic1 = splitDic1[q].ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                                                string[] everysplitDic2 = splitDic2[q].ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                                                if (everysplitDic1[1].Contains(everysplitDic2[1]) || everysplitDic2[1].Contains(everysplitDic1[1]))
                                                {
                                                    count2++;
                                                }
                                            }

                                        }
                                        if ((float)count2 / Math.Min(splitDic1.Length, splitDic2.Length) >= 0.2)
                                        {
                                            if (resultList.Contains(words1))
                                            {
                                                int index = resultList.IndexOf(words1);
                                                while (resultList[index + 1] != "")
                                                {
                                                    index++;
                                                }
                                                resultList.Insert(index + 1, words2);
                                            }
                                            else
                                            {
                                                resultList.Add(words1);
                                                resultList.Add(words2);
                                                resultList.Add("");
                                            }
                                        }
                                    }

                                }
                            }
                        }
                        else if (words1.Length >= words2.Length -1 && words1.Length <= words2.Length + 1)
                        {
                            int bothDic = bothDicMatch1(words1, words2);
                            int word1count = NLPIR.getcount(words1);
                            int word2count = NLPIR.getcount(words2);
                            if (word1count >= word2count - 1 && word1count <= word2count + 1)
                            {
                                if (bothDic >= 1)
                                {
                                    if (resultList.Contains(words1))
                                    {
                                        int index = resultList.IndexOf(words1);
                                        while (resultList[index + 1] != "")
                                        {
                                            index++;
                                        }
                                        resultList.Insert(index + 1, words2);
                                    }
                                    else
                                    {
                                        resultList.Add(words1);
                                        resultList.Add(words2);
                                        resultList.Add("");
                                    }
                                }
                            }
                            else
                            {
                                if (bothDic >= 1)
                                {
                                    if (resultList.Contains(words1))
                                    {
                                        int index = resultList.IndexOf(words1);
                                        while (resultList[index + 1] != "")
                                        {
                                            index++;
                                        }
                                        resultList.Insert(index + 1, words2);
                                    }
                                    else
                                    {
                                        resultList.Add(words1);
                                        resultList.Add(words2);
                                        resultList.Add("");
                                    }
                                }
                            }

                        }
                    }
                }
            }
            return resultList;
        }
        #endregion

        #region “。”排比
        //public List<String> setenceMatch(string words1, string words2)
        //{
        //    string filterPath = "..\\..\\filtertext.txt";
        //    FileStream fs = File.OpenRead(filterPath);
        //    StreamReader read = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
        //    string filtertext = read.ReadToEnd();
        //    string[] filterArray = filtertext.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

        //    int count = 0;
        //    int count1 = 0;
        //    for (int i = 0; i < filterArray.Length; i++)
        //    {
        //        if (words1.Contains(filterArray[i]))
        //        {
        //            count++;
        //            continue;
        //        }
        //    }
        //    for (int i = 0; i < filterArray.Length; i++)
        //    {
        //        if (words2.Contains(filterArray[i]))
        //        {
        //            count1++;
        //            continue;

        //        }
        //    }
        //    if (count == 0 && count1 == 0)
        //    {
        //        words2 = words2.Trim();
        //        words1 = words1.Trim();
        //        int mark = markMatch(words1, words2);
        //        if (mark == 1)
        //        {
        //            if (words1.Length == words2.Length)
        //            {
        //                if (resultList.Contains(words1))
        //                {
        //                    int index = resultList.IndexOf(words1);
        //                    while (resultList[index + 1] != "")
        //                    {
        //                        index++;
        //                    }
        //                    resultList.Insert(index + 1, words2);
        //                }
        //                else
        //                {
        //                    resultList.Add(words1);
        //                    resultList.Add(words2);
        //                    resultList.Add("");
        //                }
        //            }
        //            else
        //            {
        //                int bothDic = bothDicMatch1(words1, words2);
        //                if (bothDic >= 1)
        //                {
        //                    if (resultList.Contains(words1))
        //                    {
        //                        int index = resultList.IndexOf(words1);
        //                        while (resultList[index + 1] != "")
        //                        {
        //                            index++;
        //                        }
        //                        resultList.Insert(index + 1, words2);
        //                    }
        //                    else
        //                    {
        //                        resultList.Add(words1);
        //                        resultList.Add(words2);
        //                        resultList.Add("");
        //                    }
        //                }
        //            }

        //        }
        //    }
        //    return resultList;
        //}

        public List<String> setenceMatchs(string allTxt)
        {
            String[] perSession = allTxt.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int m = 0; m < perSession.Length; m++)
            {
                string[] perSetence = perSession[m].Split(new string[] { "。", "？" }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < perSetence.Length-1; j++)
                {
                    setenceMatch(perSetence[j].ToString(), perSetence[j + 1].ToString());
                }
            }
            return resultList;
        }
        public List<String> setenceMatch(string words1, string words2)
        {
            string filterPath = "..\\..\\filtertext.txt";
            FileStream fs = File.OpenRead(filterPath);
            StreamReader read = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
            string filtertext = read.ReadToEnd();
            string[] filterArray = filtertext.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            int count = 0;
            int count1 = 0;
            for (int i = 0; i < filterArray.Length; i++)
            {
                if (words1.Contains(filterArray[i]))
                {
                    count++;
                    continue;
                }
            }
            for (int i = 0; i < filterArray.Length; i++)
            {
                if (words2.Contains(filterArray[i]))
                {
                    count1++;
                    continue;

                }
            }
            if (count == 0 && count1 == 0)
            {
                words2 = words2.Trim();
                words1 = words1.Trim();
                if (Math.Abs(words1.Length - words2.Length) <= 10)   //???为什么是10
                {
                    if (Math.Min(words1.Length, words2.Length) <= 30)   //???为什么是30
                    {
                        int mark = markMatch(words1, words2);
                        //标点符号匹配成功
                        if (mark == 1)
                        {
                            //字数相同
                            if (words1.Length == words2.Length)
                            {
                                if (resultList.Contains(words1))
                                {
                                    int index = resultList.IndexOf(words1);
                                    while (resultList[index + 1] != "")
                                    {
                                        index++;
                                    }
                                    resultList.Insert(index + 1, words2);
                                }
                                else
                                {
                                    resultList.Add(words1);
                                    resultList.Add(words2);
                                    resultList.Add("");
                                }
                            }
                            //字数不同，观察共现词
                            else
                            {
                                int bothDic = bothDicMatch1(words1, words2); //共现字符串个数
                                int num = bothDicMatch2(words1, words2);//句首共现词
                                if (bothDic >= 2 || num == 1)
                                {
                                    if (resultList.Contains(words1))
                                    {
                                        int index = resultList.IndexOf(words1);
                                        while (resultList[index + 1] != "")
                                        {
                                            index++;
                                        }
                                        resultList.Insert(index + 1, words2);
                                    }
                                    else
                                    {
                                        resultList.Add(words1);
                                        resultList.Add(words2);
                                        resultList.Add("");
                                    }
                                }
                            }

                        }
                    }
                    //大于30的
                    else
                    {
                        int num = bothDicMatch2(words1, words2);
                        if (num == 1)
                        {
                            if (resultList.Contains(words1))
                            {
                                int index = resultList.IndexOf(words1);
                                while (resultList[index + 1] != "")
                                {
                                    index++;
                                }
                                resultList.Insert(index + 1, words2);
                            }
                            else
                            {
                                resultList.Add(words1);
                                resultList.Add(words2);
                                resultList.Add("");
                            }
                        }
                    }
                }

            }
            return resultList;
        }
        #endregion

        #region 句子长度相等，分词数相同，对应词性相同
        public List<String> preSetence(String allTxt)
        {
            String[] setenceArray = allTxt.Split(new char[] { '。', '？', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int n = 1;
            int[] temp = new int[setenceArray.Length * 2];
            int a = 0;
            temp[0] = -1;
            for (int m = 0; m < setenceArray.Length; m++)
            {
                if (setenceArray[m] == "\r" || setenceArray[m] == " " || setenceArray[m] == "\r\n")
                {
                    continue;
                }
               
                if (NLPIR.Init(@"F:/Project/Visual Studio 2012/Projects/TextProcess/TextProcess/",0))
                {
                    for (int j = 0; j < a; j++)
                    {
                        if (m == temp[j])
                            m++;
                    }
                    string words1 = setenceArray[m].ToString();
                    words1 = words1.Trim();
                    for (int k = m + 1; k < setenceArray.Length; k++)
                    {
                        string words2 = setenceArray[k].ToString();
                        words2 = words2.Trim();
                        if (words1.Length == words2.Length)
                        {
                            string s1 = NLPIR.ParagraphProcess(words1, true);
                            string s2 = NLPIR.ParagraphProcess(words2, true);
                            String[] splitDic1 = s1.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            String[] splitDic2 = s2.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            if (splitDic1.Length == splitDic2.Length)
                            {
                                int count = 0;
                                for (int p = 0; p < splitDic1.Length; p++)
                                {
                                    if (splitDic1[p] == "" && splitDic2[p] == "")
                                    {
                                        continue;
                                    }
                                    string[] everysplitDic1 = splitDic1[p].ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                                    string[] everysplitDic2 = splitDic2[p].ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                                    if (everysplitDic1[1].Contains(everysplitDic2[1]) || everysplitDic2[1].Contains(everysplitDic1[1]))
                                    {
                                        count++;
                                    }
                                }
                                if (count == splitDic1.Length)
                                {
                                    if (resultList.Contains(words1))
                                    {
                                        int index = resultList.IndexOf(words1);
                                        while (resultList[index + 1] != "")
                                        {
                                            index++;
                                        }
                                        resultList.Insert(index+1, words2);
                                    }
                                    else
                                    {
                                        resultList.Add(words1);
                                        resultList.Add(words2);
                                        resultList.Add("");
                                    }
                                    temp[a] = k;
                                    a++;
                                }
                            }
                        }
                    }
                    n++;
                }
            }
            //everySetence(setenceArray);
            return resultList;
        }
        #endregion

        #region 里面含有顿号的句子  需要改，将顿号前后的一个词的词性进行判断
        public List<String> everySetence(string allTxt)
        {
             string filterPath = "..\\..\\file\\filtertext.txt";
             FileStream fs = File.OpenRead(filterPath);
             StreamReader read = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
             string filtertext = read.ReadToEnd();
             string[] filterArray = filtertext.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
             
             String[] setenceArray = allTxt.Split(new char[] { '！','，','。', '？', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
             for (int m = 0; m < setenceArray.Length; m++)
             {
                int n = 0;
                for (int i = 0; i < filterArray.Length; i++)
                { 
                    if (setenceArray[m].Contains(filterArray[i]))
                    {
                        n++;
                        continue;
                    }
                }
                if (n == 0)
                {
                    int num = 0;
                    if (NLPIR.Init(@"F:/Project/Visual Studio 2012/Projects/TextProcess/TextProcess/", 0))
                    {
                        string[] everyMark = setenceArray[m].Split('、');
                        for (int j = 0; j < everyMark.Length; j++)
                        {
                            String everyDic = NLPIR.ParagraphProcess(everyMark[j].ToString(), true);
                            int count = NLPIR.getcount(everyMark[j]);
                            if (count == 1)
                            {
                                num++;
                            }
                            string[] everyDicDetail = everyDic.Split(' ');
                        }
                        if (num >0)
                        {
                            continue;
                        }
                    }
                    if (setenceArray[m].Contains("、"))
                    {
                        if (!resultList.Contains(setenceArray[m]))
                        {
                            resultList.Add(setenceArray[m] + "。");
                            resultList.Add("");
                        }
                    }
                }
                 
             }
            return resultList;
        }
        #endregion       

        #region 相邻两句字数相同  用
        public List<String> closeMatch3(String allTxt)
        {
            string filterPath = "..\\..\\filtertext.txt";
            FileStream fs = File.OpenRead(filterPath);
            StreamReader read = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
            string filtertext = read.ReadToEnd();
            string[] filterArray = filtertext.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            String[] perSession = allTxt.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            
            for (int m = 0; m < perSession.Length; m++)
            {
                String[] setenceArray = perSession[m].Split(new char[] { '。', '？', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                for (int n = 0; n < setenceArray.Length; n++)
                {
                    if (setenceArray[n].ToString()[0].Equals("”"))
                    {
                        setenceArray[n].ToString().Substring(1);
                    }
                    if (setenceArray[n].Contains('，') || setenceArray[n].Contains('！') || setenceArray[n].Contains('：'))
                    {
                        
                        String[] everysetenceArray = setenceArray[n].Split(new char[] { '，','：','！' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int p = 0; p < everysetenceArray.Length; p++)
                        {
                            if (everysetenceArray[p].Equals("亚洲基础设施投资银行已经为“一带一路”建设参与国的9个项目提供17亿美元贷款"))
                            {
                                string sb = "";
                            }
                            if (p == 0)
                            {
                                continue;
                            }

                            int count = 0;
                            int count1 = 0;
                            for (int i = 0; i < filterArray.Length; i++)
                            {
                                if (everysetenceArray[p].Contains(filterArray[i]))
                                {
                                    count++;
                                    continue;

                                }
                            }
                            for (int i = 0; i < filterArray.Length; i++)
                            {
                                if (everysetenceArray[p - 1].Contains(filterArray[i]))
                                {
                                    count1++;
                                    continue;

                                }
                            }
                            if (count == 0 && count1==0)
                            {
                                string words2 = everysetenceArray[p].ToString();
                                words2 = words2.Trim();
                                string words1 = everysetenceArray[p - 1].ToString();
                                words1 = words1.Trim();
                                
                                int mark = markMatch(words1,words2);
                                if (mark == 1)
                                {


                                    if (words1.Length == words2.Length)
                                    {
                                        int bothDic = bothDicMatch1(words1, words2);
                                        if (bothDic >= 1)
                                        {
                                            if (resultList.Contains(words1))
                                            {
                                                int index = resultList.IndexOf(words1);
                                                while (resultList[index + 1] != "")
                                                {
                                                    index++;
                                                }
                                                resultList.Insert(index + 1, words2);
                                            }
                                            else
                                            {
                                                resultList.Add(words1);
                                                resultList.Add(words2);
                                                resultList.Add("");
                                            }
                                        }
                                        else
                                        {
                                            if (NLPIR.getcount(words1) >= NLPIR.getcount(words2) - 2 && NLPIR.getcount(words1) <= NLPIR.getcount(words2) + 2)
                                            {
                                                if (Math.Min(words1.Length, words2.Length) <= 4)
                                                {
                                                    if (resultList.Contains(words1))
                                                    {
                                                        int index = resultList.IndexOf(words1);
                                                        while (resultList[index + 1] != "")
                                                        {
                                                            index++;
                                                        }
                                                        resultList.Insert(index + 1, words2);
                                                    }
                                                    else
                                                    {
                                                        resultList.Add(words1);
                                                        resultList.Add(words2);
                                                        resultList.Add("");
                                                    }
                                                }
                                                else
                                                {
                                                    string s1 = NLPIR.ParagraphProcess(words1, true);
                                                    string s2 = NLPIR.ParagraphProcess(words2, true);
                                                    String[] splitDic1 = s1.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                                                    String[] splitDic2 = s2.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                                                    int count2 = 0;
                                                    for (int q = 0; q < Math.Min(splitDic1.Length, splitDic2.Length); q++)
                                                    {
                                                        if (splitDic1[q] != "" && splitDic2[q] != "")
                                                        {
                                                            string[] everysplitDic1 = splitDic1[q].ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                                                            string[] everysplitDic2 = splitDic2[q].ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                                                            if (everysplitDic1[1].Contains(everysplitDic2[1]) || everysplitDic2[1].Contains(everysplitDic1[1]))
                                                            {
                                                                count2++;
                                                            }
                                                        }

                                                    }
                                                    if ((float)count2 / Math.Min(splitDic1.Length, splitDic2.Length) >= 0.2)
                                                    {
                                                        if (resultList.Contains(words1))
                                                        {
                                                            int index = resultList.IndexOf(words1);
                                                            while (resultList[index + 1] != "")
                                                            {
                                                                index++;
                                                            }
                                                            resultList.Insert(index + 1, words2);
                                                        }
                                                        else
                                                        {
                                                            resultList.Add(words1);
                                                            resultList.Add(words2);
                                                            resultList.Add("");
                                                        }
                                                    }
                                                }
                                                
                                            }
                                        }
                                    }
                                    else if (words1.Length >= words2.Length - 6 && words1.Length <= words2.Length+6)
                                    {
                                        int bothDic = bothDicMatch1(words1, words2);
                                        int word1count = NLPIR.getcount(words1);
                                        int word2count = NLPIR.getcount(words2);
                                        if (word1count >= word2count - 1 && word1count <= word2count + 1)
                                        {
                                            if (bothDic >= 1)
                                            {
                                                if (resultList.Contains(words1))
                                                {
                                                    int index = resultList.IndexOf(words1);
                                                    while (resultList[index + 1] != "")
                                                    {
                                                        index++;
                                                    }
                                                    resultList.Insert(index + 1, words2);
                                                }
                                                else
                                                {
                                                    resultList.Add(words1);
                                                    resultList.Add(words2);
                                                    resultList.Add("");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (bothDic >= 1)
                                            {
                                                if (resultList.Contains(words1))
                                                {
                                                    int index = resultList.IndexOf(words1);
                                                    while (resultList[index + 1] != "")
                                                    {
                                                        index++;
                                                    }
                                                    resultList.Insert(index + 1, words2);
                                                }
                                                else
                                                {
                                                    resultList.Add(words1);
                                                    resultList.Add(words2);
                                                    resultList.Add("");
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                            
                        }
                    }
                    else    //“。”排比
                    {
                        if (n == 0)
                        {
                            continue;
                        }
                        
                        int count = 0;
                        int count1 = 0;
                        for (int i = 0; i < filterArray.Length; i++)
                        {
                            if (setenceArray[n].Contains(filterArray[i]))
                            {
                                count++;
                                continue;

                            }
                        }
                        for (int i = 0; i < filterArray.Length; i++)
                        {
                            if (setenceArray[n - 1].Contains(filterArray[i]))
                            {
                                count1++;
                                continue;

                            }
                        }
                        if (count == 0 && count1 == 0)
                        {
                            string words2 = setenceArray[n].ToString();
                            words2 = words2.Trim();
                            string words1 = setenceArray[n - 1].ToString();
                            words1 = words1.Trim();
                            int mark = markMatch(words1,words2);
                            if (mark == 1)
                            {
                                if (words1.Length == words2.Length)
                                {
                                    if (resultList.Contains(words1))
                                    {
                                        int index = resultList.IndexOf(words1);
                                        while (resultList[index + 1] != "")
                                        {
                                            index++;
                                        }
                                        resultList.Insert(index + 1, words2);
                                    }
                                    else
                                    {
                                        resultList.Add(words1);
                                        resultList.Add(words2);
                                        resultList.Add("");
                                    }
                                }
                                else
                                {
                                    int bothDic = bothDicMatch1(words1, words2);
                                    if (bothDic >= 1)
                                    {
                                        if (resultList.Contains(words1))
                                        {
                                            int index = resultList.IndexOf(words1);
                                            while (resultList[index + 1] != "")
                                            {
                                                index++;
                                            }
                                            resultList.Insert(index + 1, words2);
                                        }
                                        else
                                        {
                                            resultList.Add(words1);
                                            resultList.Add(words2);
                                            resultList.Add("");
                                        }
                                    }
                                }
                           
                            }
                                
                           }
                        
                    }                       
                }
            }
            return resultList;
        }
        #endregion

        #region 最严格 相邻两句字数相同，且分词数相同,且对应词性相近
        public List<String> closeMatch(String allTxt)
        {
            String[] setenceArray = allTxt.Split(new char[] { '，', '。', '？', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int m = 0; m < setenceArray.Length - 1; m++)
            {
                if (setenceArray[m] == "\r" || setenceArray[m] == " " || setenceArray[m] == "\r\n")
                {
                    continue;
                }

                string filterPath = "..\\..\\filtertext.txt";
                FileStream fs = File.OpenRead(filterPath);
                StreamReader read = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
                string filtertext = read.ReadToEnd();
                string[] filterArray = filtertext.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                int count = 0;
                int count1 = 0;
                for (int i = 0; i < filterArray.Length; i++)
                {
                    if (setenceArray[m].Contains(filterArray[i]))
                    {
                        count++;
                        continue;
                    }
                }
                for (int i = 0; i < filterArray.Length; i++)
                {
                    if (setenceArray[m + 1].Contains(filterArray[i]))
                    {
                        count1++;
                        continue;

                    }
                }
                if (count == 0 && count1 == 0)
                {
                    string words1 = setenceArray[m].ToString();
                    words1 = words1.Trim();
                    if (NLPIR.Init(@"F:/Project/Visual Studio 2012/Projects/TextProcess/TextProcess/", 0))
                    {
                        string words2 = setenceArray[m + 1].ToString();
                        words2 = words2.Trim();
                        int mark = markMatch(words1, words2);
                        if (mark == 1)
                        {
                            if (words1.Length == words2.Length)
                            {
                                string s1 = NLPIR.ParagraphProcess(words1, true);
                                string s2 = NLPIR.ParagraphProcess(words2, true);
                                String[] splitDic1 = s1.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                                String[] splitDic2 = s2.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                                if (NLPIR.getcount(words1) == NLPIR.getcount(words2))
                                {
                                    s1 += "    " + splitDic1.Length;
                                    s2 += "    " + splitDic2.Length;
                                    int count3 = 0;
                                    for (int p = 0; p < Math.Min(splitDic1.Length, splitDic2.Length); p++)
                                    {
                                        if (splitDic1[p] == "" && splitDic2[p] == "")
                                        {
                                            continue;
                                        }
                                        string[] everysplitDic1 = splitDic1[p].ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                                        string[] everysplitDic2 = splitDic2[p].ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                                        if (splitDic1[p] != "" && splitDic2[p] != "")
                                        {
                                            if (everysplitDic1[1].Contains(everysplitDic2[1]) || everysplitDic2[1].Contains(everysplitDic1[1]))
                                            {
                                                count3++;
                                            }
                                        }
                                    }
                                    if (count3 >= 2)
                                    {
                                        if (resultList.Contains(words1))
                                        {
                                            int index = resultList.IndexOf(words1);
                                            while (resultList[index + 1] != "")
                                            {
                                                index++;
                                            }
                                            resultList.Insert(index + 1, words2);
                                        }
                                        else
                                        {
                                            resultList.Add(words1);
                                            resultList.Add(words2);
                                            resultList.Add("");
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
                }
            return resultList;
        }


        //public List<String> closeMatch(String allTxt)
        //{
        //    String[] setenceArray = allTxt.Split(new char[] { '，', '。', '？', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        //    for (int m = 0; m < setenceArray.Length - 1; m++)
        //    {
        //        if (setenceArray[m] == "\r" || setenceArray[m] == " " || setenceArray[m] == "\r\n")
        //        {
        //            continue;
        //        }
        //        string words1 = setenceArray[m].ToString();
        //        words1 = words1.Trim();
        //        if (NLPIR.Init(@"F:/Project/Visual Studio 2012/Projects/TextProcess/TextProcess/", 0))
        //        {
        //            string words2 = setenceArray[m + 1].ToString();
        //            words2 = words2.Trim();
        //            int mark = markMatch(words1,words2);
        //            if (mark == 1)
        //            {
        //                if (words1.Length >= words2.Length - 2 && words1.Length <= words2.Length - 2)
        //                {
        //                    string s1 = NLPIR.ParagraphProcess(words1, true);
        //                    string s2 = NLPIR.ParagraphProcess(words2, true);
        //                    String[] splitDic1 = s1.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        //                    String[] splitDic2 = s2.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        //                    if (NLPIR.getcount(words1) >= NLPIR.getcount(words2) - 2 && NLPIR.getcount(words1) <= NLPIR.getcount(words2) + 2)
        //                    {
        //                        s1 += "    " + splitDic1.Length;
        //                        s2 += "    " + splitDic2.Length;
        //                        int count = 0;
        //                        for (int p = 0; p < Math.Min(splitDic1.Length, splitDic2.Length); p++)
        //                        {
        //                            if (splitDic1[p] == "" && splitDic2[p] == "")
        //                            {
        //                                continue;
        //                            }
        //                            string[] everysplitDic1 = splitDic1[p].ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
        //                            string[] everysplitDic2 = splitDic2[p].ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
        //                            if (splitDic1[p] != "" && splitDic2[p] != "")
        //                            {
        //                                if (everysplitDic1[1].Contains(everysplitDic2[1]) || everysplitDic2[1].Contains(everysplitDic1[1]))
        //                                {
        //                                    count++;
        //                                }
        //                            }
        //                        }
        //                        if (count >= 2)
        //                        {
        //                            if (resultList.Contains(words1))
        //                            {
        //                                int index = resultList.IndexOf(words1);
        //                                while (resultList[index + 1] != "")
        //                                {
        //                                    index++;
        //                                }
        //                                resultList.Insert(index + 1, words2);
        //                            }
        //                            else
        //                            {
        //                                resultList.Add(words1);
        //                                resultList.Add(words2);
        //                                resultList.Add("");
        //                            }
        //                        }
        //                    }
        //                }
        //            }
                    
        //        }
        //    }
        //    return resultList;
        //}
        #endregion

        #region 相邻两句字数相同，且分词数相同
        public List<String> closeMatch2(String allTxt)
        {
            string filterPath = "..\\..\\filtertext.txt";
            FileStream fs = File.OpenRead(filterPath);
            StreamReader read = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
            string filtertext = read.ReadToEnd();
            string[] filterArray = filtertext.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            String[] perSession = allTxt.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int n = 0; n < perSession.Length - 1; n++)
            {
                perSession[n].ToString().Trim();
                String[] setenceArray = perSession[n].Split(new char[] { '，', '。', '？' });
                for (int m = 0; m < setenceArray.Length - 2; m++)
                {
                    if (setenceArray[m] == "\r" || setenceArray[m] == " ")
                    {
                        continue;
                    }
                    string words1 = setenceArray[m].ToString();
                    words1 = words1.Trim();
                    if (words1.Equals("坚定信心"))
                    {
                        string s = "";
                    }
                    if (NLPIR.Init(@"F:/Project/Visual Studio 2012/Projects/TextProcess/TextProcess/", 0))
                    {
                        string words2 = setenceArray[m + 1].ToString();
                        words2 = words2.Trim();
                        if (words1.Length == words2.Length)
                        {
                            string s1 = NLPIR.ParagraphProcess(words1, true);
                            s1=s1.Trim();
                            string s2 = NLPIR.ParagraphProcess(words2, true);
                            s2=s2.Trim();
                            String[] splitDic1 = s1.Split(' ');
                            String[] splitDic2 = s2.Split(' ');
                            if (splitDic1.Length == splitDic2.Length || splitDic1.Length == splitDic2.Length+1 || splitDic1.Length == splitDic2.Length-1)
                            {
                                s1 += "    " + splitDic1.Length;
                                s2 += "    " + splitDic2.Length;
                                if (resultList.Contains(words1))
                                {
                                    int index = resultList.IndexOf(words1);
                                    resultList.Insert(index, words2);
                                    resultList.Add("");
                                }
                                else
                                {
                                    resultList.Add(words1);
                                    resultList.Add(words2);
                                    resultList.Add("");
                                }
                            }
                        }
                    }
                }
            }
            return resultList;
        }
        #endregion

        #region 引用排比 用
        //public List<String> citeSearchMatch(string allTxt)
        //{
        //    String[] perSession = allTxt.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        //    for (int m = 0; m < perSession.Length - 1; m++)
        //    {
        //        String[] setenceArray = perSession[m].Split(new char[] { '！', '。', '”', '？', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        //        for (int n = 0; n < setenceArray.Length; n++)
        //        {
        //            if (setenceArray[n].Contains("“"))
        //            {
        //                if (setenceArray[n].Contains("”"))
        //                {
        //                    for (int i = 0; i < setenceArray[n].Length; i++)
        //                    {
        //                        if (setenceArray[n][i].ToString().Equals("“"))
        //                        {
        //                            int w = i + 1;
        //                            for (int p = i + 1; p < setenceArray[n].Length; p++)
        //                            {
        //                                if (setenceArray[n][p].ToString().Equals("”"))
        //                                {
        //                                    int v = p - 1;
        //                                    string citestr = setenceArray[n].ToString().Substring(w, v - w + 1);
        //                                    if (!resultList.Contains(citestr))
        //                                    {
        //                                        if (citestr.Contains("，") || citestr.Contains("。") || citestr.Contains("、"))
        //                                        {
        //                                            resultList.Add(citestr);
        //                                            resultList.Add("");
        //                                            break;
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    int i = setenceArray[n].IndexOf("“") + 1;
        //                    int j = setenceArray[n].Length - 1;
        //                    string citestr = setenceArray[n].ToString().Substring(i, j - i + 1);
        //                    if (!resultList.Contains(citestr))
        //                    {
        //                        if (citestr.Contains("，"))
        //                        {
        //                            resultList.Add(citestr);
        //                            resultList.Add("");
        //                        }
        //                    }
        //                }

        //            }
        //        }
        //    }
        //    return resultList;
        //}

        public List<String> citeSearchMatch(string allTxt)
        {
            String[] perSession = allTxt.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int m = 0; m < perSession.Length - 1; m++)
            {
                String setenceArray = perSession[m].ToString();
                if (setenceArray.Contains('“'))
                {
                    for (int n = 0; n < setenceArray.Length; n++)
                    {
                        if (setenceArray[n].ToString().Equals("“"))
                        {
                            int w = n + 1;
                            for (int p = n + 1; p < setenceArray.Length; p++)
                            {
                                if (setenceArray[p].ToString().Equals("”"))
                                {
                                    int v = p - 1;
                                    string citestr = setenceArray.Substring(w, v - w + 1);
                                    //句子长度小于20的
                                    if (citestr.Length <= 20)
                                    {
                                        if (!resultList.Contains(citestr))
                                        {
                                            if (citestr.Contains("，") || citestr.Contains("。") || citestr.Contains("、"))
                                            {
                                                if (citestr.Contains("。") && !citestr.Contains("，") && !citestr.Contains("、"))
                                                {
                                                    int index = citestr.IndexOf('。');
                                                    if (index != citestr.Length-1)
                                                    {
                                                        resultList.Add(citestr);
                                                        resultList.Add("");
                                                    }
                                                }
                                                else
                                                {
                                                    resultList.Add(citestr);
                                                    resultList.Add("");
                                                }
                                            }
                                        }                                        
                                    }
                                    n = p + 1;
                                    break;
                                }
                            }
                        }
                    }
                }
              }
            return resultList;
        }
        #endregion

        #region 段内包含分号的句子 用
        //public List<String> inStrictMatch(string allTxt)
        //{
        //    String[] perSession = allTxt.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        //    for (int m = 0; m < perSession.Length; m++)
        //    {
        //        string[] perSetence = perSession[m].Split(new string[] { "。", "！", "？" }, StringSplitOptions.RemoveEmptyEntries);
        //        for (int j = 0; j < perSetence.Length; j++)
        //        {
        //            if (perSetence[j].ToString()[0].Equals("”"))
        //            {
        //                perSetence[j].ToString().Substring(1);
        //            }
        //            if (perSetence[j].Contains("；"))
        //            {
        //                resultList.Add(perSetence[j] + "。");
        //                resultList.Add("");
        //            }
        //        }
        //    }
        //    return resultList;
        //}

        public List<String> inStrictMatch(string allTxt)
        {
            String[] perSession = allTxt.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int m = 0; m < perSession.Length; m++)
            {
                string[] perSetence = perSession[m].Split(new string[] { "。", "！", "？" }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < perSetence.Length; j++)
                {
                    double p=0.0;
                    if (perSetence[j].ToString()[0].Equals("”"))
                    {
                        perSetence[j].ToString().Substring(1);
                    }
                    if (perSetence[j].Contains("；"))
                    {
                        p=p+0.8;
                        int index=perSetence[j].IndexOf("；");

                        if (index + 1 < perSetence[j].Length)
                        {
                            p = p + 0.1;
                            string substring = perSetence[j].Substring(index-8,17);
                            if (!substring.Contains("“") && !substring.Contains("”"))
                            {
                                p = p + 0.1;
                                string[] splitSte = perSetence[j].Split('；');
                                string result="";
                                for (int i = 0; i < splitSte.Length; i++)
                                {
                                    result += splitSte[i] + "； ";
                                }
                                resultList.Add(result);
                                resultList.Add("");
                            }
                        }
                    }
                }
            }
            return resultList;
        }
        #endregion     

        #region 引用,不加“，”判断的 暂时没用
        public List<String> cite(string allTxt)
        {
            String[] perSession = allTxt.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int m = 0; m < perSession.Length - 1; m++)
            {
                String[] setenceArray = perSession[m].Split(new char[] { '！', '。','”', '？', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                for (int n= 0; n < setenceArray.Length; n++)
                {
                    if (setenceArray[n].Contains("“"))
                    {
                        if (setenceArray[n].Contains("”"))
                        {
                            int i = setenceArray[n].IndexOf("“") + 1;
                            int j = setenceArray[n].IndexOf("”") - 1;
                            string citestr = setenceArray[n].ToString().Substring(i, j - i + 1);
                            if (!resultList.Contains(citestr))
                            {
                                resultList.Add(citestr);
                                resultList.Add("");
                            }
                        }
                        else
                        {
                            int i = setenceArray[n].IndexOf("“") + 1;
                            int j = setenceArray[n].Length - 1;
                            string citestr = setenceArray[n].ToString().Substring(i, j - i + 1);
                            if (!resultList.Contains(citestr))
                            {
                                resultList.Add(citestr);
                                resultList.Add("");
                            }
                        }
                        
                    }
                }
            }
            return resultList;
        }
        #endregion

        #region 共现词判断
        public int bothDicMatch1(String words1, string words2)
        {
            int num = 0;
            for (int i = 0; i < words1.Length; i++)
            {
                if (i < words1.Length - 1)
                {
                    int n = 0;
                    string s = words1[i].ToString();

                    while (words2.Contains(s))
                    {
                        n++;
                        i = i + 1;
                        s += words1[i].ToString();
                        if (i >= words1.Length-1)
                        {
                            break;
                        }
                    }
                    if (n >= 2)
                    {
                        num++;
                    }
                }
                else
                {
                    continue;
                }      
            }
            return num;
        }
        #endregion

        #region 段间综合
        public List<String> allout(string allTxt)
        {
            String[] perSession = allTxt.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int[] temp = new int[perSession.Length * 2];
            int a = 0;
            temp[0] = -1;
            for (int m = 0; m < perSession.Length - 1; m++)
            {
                //找出第一类段间排比，连着三段。
                string lastchar = perSession[m].Substring(perSession[m].Length - 1, 1);
                if (lastchar.Equals("；"))
                {
                    if (resultList.Contains(perSession[m]))
                    {
                        if (resultList.Contains(perSession[m + 1]))
                        {
                            continue;
                        }
                        else
                        {
                            int index = resultList.IndexOf(perSession[m]);
                            while (resultList[index + 1] != "")
                            {
                                index++;
                            }
                            resultList.Insert(index + 1, perSession[m + 1]);
                            temp[a] = m + 1;
                            a++;
                        }
                    }
                    else
                    {
                        resultList.Add(perSession[m]);
                        resultList.Add(perSession[m + 1]);
                        resultList.Add("");
                        temp[a] = m;
                        a++;
                        temp[a] = m + 1;
                        a++;
                    }
                }
            }
            for (int m = 0; m < perSession.Length - 1; m++)
            {
                //第二种和第三种
                //if (m == 0)
                //{
                //    continue;
                //}
                for (int j = 0; j < a; j++)
                {
                    if (m == temp[j])
                        m++;
                }
                perSession[m].Trim();
                string[] word1 = perSession[m].Split(new string[] { "。" }, StringSplitOptions.RemoveEmptyEntries);
                string words1 = word1[0].Trim();
                for (int k = m + 1; k < perSession.Length; k++)
                {
                    string[] word2 = perSession[k].Split(new string[] { "。" }, StringSplitOptions.RemoveEmptyEntries);
                    string words2 = word2[0].Trim();
                    if (words1.Contains("——在前进道路上") && words2.Contains("——在前进道路上"))
                    {
                        string ss = "";
                    }
                    //过滤女士们，先生们之类的句子
                    string filterPath = "..\\..\\filtertext.txt";
                    FileStream fs = File.OpenRead(filterPath);
                    StreamReader read = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
                    string filtertext = read.ReadToEnd();
                    string[] filterArray = filtertext.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    int n = 0;
                    for (int i = 0; i < filterArray.Length; i++)
                    {
                        if (words1.Contains(filterArray[i]))
                        {
                            n++;
                            continue;
                        }
                    }
                    if (n == 0)
                    {
                       
                        //找出第二种段间排比，只有一句话的。
                        if (word1.Length == 1 && word2.Length == 1)
                        {
                            int match = outMatchRule(words1, words2);
                            if (match == 1)
                            {
                                if (resultList.Contains(words1))
                                {
                                    if (resultList.Contains(words2))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        int index = resultList.IndexOf(words1);
                                        while (resultList[index + 1] != "")
                                        {
                                            index++;
                                        }
                                        resultList.Insert(index + 1, words2);
                                    }
                                }
                                else
                                {
                                    resultList.Add(words1);
                                    resultList.Add(words2);
                                    resultList.Add("");
                                }
                                temp[a] = k;
                                a++;
                            }
                        }
                        else if (word1.Length > 1 && word2.Length > 1)   //找出第三种段间排比，每段第一句话。
                        {
                            int match = outMatchRule(words1, words2);
                            if (match == 1)
                            {
                                if (resultList.Contains(words1))
                                {
                                    if (resultList.Contains(words2))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        int index = resultList.IndexOf(words1);
                                        while (resultList[index + 1] != "")
                                        {
                                            index++;
                                        }
                                        resultList.Insert(index + 1, words2);
                                    }
                                }
                                else
                                {
                                    resultList.Add(words1);
                                    resultList.Add(words2);
                                    resultList.Add("");
                                }
                                temp[a] = k;
                                a++;
                            }
                            else
                            {
                                //int bothDic = bothDicMatch(words1, words2);
                                //if (bothDic == 1)
                                //{
                                //    if (resultList.Contains(words1))
                                //    {
                                //        if (resultList.Contains(words2))
                                //        {
                                //            continue;
                                //        }
                                //        else
                                //        {
                                //            int index = resultList.IndexOf(words1);
                                //            while (resultList[index + 1] != "")
                                //            {
                                //                index++;
                                //            }
                                //            resultList.Insert(index + 1, words2);
                                //        }
                                //    }
                                //    else
                                //    {
                                //        resultList.Add(words1);
                                //        resultList.Add(words2);
                                //        resultList.Add("");
                                //    }
                                //    temp[a] = k;
                                //    a++;
                                //}
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            return resultList;
        }
        #endregion

        #region 共现词判断
        public int bothDicMatch(String words1,string words2)
        {
            int num = 0;
            for (int i = 0; i < Math.Min(words1.Length,words2.Length); i++)
            {
                if (words1[i].Equals(words2[i]))
                {
                    num++;
                }
            }
            if (num >= 6)
            {
                num = 1;
            }
            else
            {
                num = 0;
            }
            return num;
        }
        #endregion

        #region 句首共现词判断
        public int bothDicMatch2(String words1, string words2)
        {
            int num = 0;
            for (int i = 0; i < Math.Min(words1.Length, words2.Length); i++)
            {
                if (words1[i].Equals(words2[i]))
                {
                    num++;
                }
                else
                {
                    break;
                }
            }
            if (num >= 2)
            {
                num = 1;
            }
            else
            {
                num = 0;
            }
            return num;
        }
        #endregion

        #region 样本中标点符号的匹配度
        public int markMatch(String words1, string words2)
        {
            string filterPath = "..\\..\\marktext.txt";
            FileStream fs = File.OpenRead(filterPath);
            StreamReader read = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
            string marktext = read.ReadToEnd();
            string[] markArray = marktext.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<int> mark=new List<int>();
            string[] words1Mark = new string[words1.Length];
            string[] words2Mark = new string[words2.Length];
            int words1MarkCount = 0;
            for (int m = 0; m < words1.Length; m++)
            {
                for (int i = 0; i < markArray.Length; i++)
                {
                    if (words1[m].ToString().Equals(markArray[i]))
                    {
                        words1Mark[words1MarkCount] = words1[m].ToString();
                        words1MarkCount++;
                    }
                }
            }
            int words2MarkCount = 0;
            for (int n = 0; n < words2.Length; n++)
            {
                for (int i = 0; i < markArray.Length; i++)
                {
                    if (words2[n].ToString().Equals(markArray[i]))
                    {
                        words2Mark[words2MarkCount] = words2[n].ToString();
                        words2MarkCount++;
                    }
                }
            }
            //对两个数组进行比较
            
            if (words1MarkCount == words2MarkCount)
            {
                int count = 0;
                for (int p = 0; p < words1MarkCount; p++)
                {
                    if (words1Mark[p].Equals(words2Mark[p]))
                    {
                        count++;
                    }
                }
                if (count == words1MarkCount)
                {
                    string[] words1Array = words1.Split(new string[] {"，","（","）","、","："}, StringSplitOptions.RemoveEmptyEntries);
                    string[] words2Array = words2.Split(new string[] { "，", "（", "）", "、", "：" }, StringSplitOptions.RemoveEmptyEntries);
                    if (words1Array.Length != 1 && words2Array.Length != 1)
                    {
                        if (words1Array[0].ToString().Length == words2Array[0].ToString().Length)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
            
        }
        #endregion

        #region 两句话是否排比的判断规则
        public int outMatchRule(String words1, string words2)
        {
            int num = 0;
            int mark = markMatch(words1, words2);
            //标点符号匹配成功
            if (mark == 1)
            {
                if (words1.Length == words2.Length)
                {
                    if (NLPIR.getcount(words1) >= NLPIR.getcount(words2) - 2 && NLPIR.getcount(words1) <= NLPIR.getcount(words2) +2)
                    {
                        num=1;
                    }
                    int ss = NLPIR.getcount(words1);
                    int sss = NLPIR.getcount(words2);
                }
                else if (words1.Length >= words2.Length - 2 && words1.Length <= words2.Length + 2)
                {
                    int bothnum = bothDicMatch1(words1, words2);
                    //if ((float)bothnum / Math.Max(words1.Length, words2.Length) > 0.2)
                    //{
                    //    num=1;
                    //}
                    if (bothnum>=1)
                    {
                        num = 1;
                    }

                }
                else if (words1.Length >= words2.Length - 8 && words1.Length <= words2.Length + 8)
                {
                    int bothnum = bothDicMatch1(words1, words2);
                    int num1 = 0;
                    int num2 = 0;
                    //if ((float)bothnum / Math.Max(words1.Length, words2.Length) > 0.1)
                    //{
                    //    num1 = 1;
                    //}
                    if (bothnum>=1)
                    {
                        num1 = 1;
                    }
                    int count = 0;
                    string s1 = NLPIR.ParagraphProcess(words1, true);
                    string s2 = NLPIR.ParagraphProcess(words2, true);
                    string[] s1Dic = s1.Split(' ');
                    string[] s2Dic = s2.Split(' ');
                    for (int m = 0; m < Math.Min(Math.Min(s1Dic.Length, s2Dic.Length) - 1, 3); m++)
                    {
                        string[] s1DicC = s1Dic[m].Split('/');
                        string[] s2DicC = s2Dic[m].Split('/');
                        if (s1Dic[m] != "" && s2Dic[m] != "")
                        {
                            if (s1DicC[1].Contains(s2DicC[1]) || s2DicC[1].Contains(s1DicC[1]))
                            {
                                count++;
                            }
                        }
                    }
                    if ((float)(count / Math.Min(s1Dic.Length, s2Dic.Length)) >= 0.2)
                    {
                        num2 = 1;
                    }
                    else
                    {
                        num2 = 0;
                    }
                    num = num1 & num2;
                }
            }
            else
            {
                num = 0;
            }
            return num;
        }
        #endregion

        #region 分词数相等时，对应词性判断
        public int characteristicMatch(String words1, string words2)
        {
            int num = 0;
            string s1 = NLPIR.ParagraphProcess(words1, true);
            string s2 = NLPIR.ParagraphProcess(words2, true);
            string[] s1Dic = s1.Split(' ');
            string[] s2Dic = s2.Split(' ');
            if (NLPIR.getcount(words1) == NLPIR.getcount(words2))
            {
                for (int m = 0; m < s1Dic.Length; m++)
                {
                    string[] s1DicC = s1Dic[m].Split('/');
                    string[] s2DicC = s2Dic[m].Split('/');
                    if (s1DicC[1].Contains(s2DicC[1]) || s2DicC[1].Contains(s1DicC[1]))
                    {
                        num++;
                    }
                }
            }
            if ((float)num / NLPIR.getcount(words1) >= 0.5)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region 分词数不相等时，对应词性判断
        public int characteristicMatch1(String words1, string words2)
        {
            int num = 0;
            string s1 = NLPIR.ParagraphProcess(words1, true);
            string s2 = NLPIR.ParagraphProcess(words2, true);
            string[] s1Dic = s1.Split(' ');
            string[] s2Dic = s2.Split(' ');
            if (NLPIR.getcount(words1) >= NLPIR.getcount(words2) - 1 && NLPIR.getcount(words1) <= NLPIR.getcount(words2) + 1)
            {
                for (int m = 1; m < s1Dic.Length-1; m++)
                {
                    string[] s1DicC = s1Dic[m].Split('/');
                    string[] s2DicC = s2Dic[m].Split('/');
                    string[] s1DicC1 = s1Dic[m-1].Split('/');
                    string[] s2DicC1 = s2Dic[m-1].Split('/');
                    string[] s1DicC2 = s1Dic[m + 1].Split('/');
                    string[] s2DicC2 = s2Dic[m + 1].Split('/');
                    if (s1DicC[1].Contains(s2DicC[1]) || s1DicC[1].Contains(s2DicC1[1]) || s1DicC[1].Contains(s2DicC2[1]) || s2DicC[1].Contains(s1DicC[1]) || s2DicC[1].Contains(s1DicC1[1]) || s2DicC[1].Contains(s1DicC2[1]))
                    {
                        num++;
                    }
                }
            }
            if ((float)num / NLPIR.getcount(words1) >= 0.5)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        #endregion


    }
}

