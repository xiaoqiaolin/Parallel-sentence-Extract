using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProcess
{
    class SimilarProcess
    { //全局变量
        List<String> resultList = new List<String>();   //接收最后结果

        //#region 分词数相等
        //public List<String> preSetence(String allTxt)
        //{
        //    String[] setenceArray = allTxt.Split(new char[] { '，', '。', '？','r' });
        //    int n = 1;
        //    for (int m = 0; m < setenceArray.Length; m++)
        //    {
        //        if (m == 0)
        //        {
        //            continue;
        //        }
        //        if (setenceArray[m] == "\r" || setenceArray[m] == " ")
        //        {
        //            continue;
        //        }
        //        string words1 = setenceArray[m].ToString();
        //        words1 = words1.Trim();
        //        if (NLPIR.Init(@"F:/Project/Visual Studio 2012/Projects/TextProcess/TextProcess/", 0))
        //        {
        //                string words2 = setenceArray[m-1].ToString();
        //                words2 = words2.Trim();
        //                    string s1 = NLPIR.ParagraphProcess(words1, true);
        //                    string s2 = NLPIR.ParagraphProcess(words2, true);
        //                    String[] splitDic1 = s1.Split(' ');
        //                    String[] splitDic2 = s2.Split(' ');
        //                    if (splitDic1.Length == splitDic2.Length)
        //                    {
        //                        s1 += "    " + splitDic1.Length;
        //                        s2 += "    " + splitDic2.Length;
        //                        if (resultList.Contains(setenceArray[m]))
        //                        {
        //                            int index = resultList.IndexOf(words1);
        //                            resultList.Insert(index, words2);
        //                        }
        //                        else
        //                        {
        //                            resultList.Add(words1);
        //                            resultList.Add(words2);
        //                        }
        //                    }
        //            n++;
        //        }
        //    }
        //    return resultList;
        //}
        //#endregion

        #region 分词数相等，对应词性相近
        public List<String> preSetence(String allTxt)
        {
            String[] setenceArray = allTxt.Split(new char[] { '，', '。', '？', 'r', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int n = 1;
            for (int m = 0; m < setenceArray.Length-1; m++)
            {
                if (setenceArray[m] == "\r" || setenceArray[m] == " " || setenceArray[m] == "\r\n")
                {
                    continue;
                }
                string words1 = setenceArray[m].ToString();
                words1 = words1.Trim();
                if (NLPIR.Init(@"F:/Project/Visual Studio 2012/Projects/TextProcess/TextProcess/", 0))
                {
                    string words2 = setenceArray[m+1].ToString();
                    words2 = words2.Trim();
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
                            if (resultList.Contains(setenceArray[m]))
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
                        }
                    }
                    n++;
                }
            }
            return resultList;
        }
        #endregion

        #region 针对段首的检索
        public List<String> preSection1(String allTxt)
        {
            List<String> list = new List<String>();      //接收每段首句。
            //List<String> list1 = new List<String>();
            String[] sectionArray = allTxt.Split('\n');
            int count = 0;

            for (int i = 0; i < sectionArray.Length; i++)
            {
                String sentence = sectionArray[i];
                String[] sentenceArray = sentence.Split(new char[] { '，', '。' });
                list.Add(sentenceArray[0]);
            }
            //resultList.Add(list[1]+"\n");
            int[] temp = new int[list.Count];
            int a = 0;
            temp[0] = -1;
            for (int j = 0; j < list.Count; j++)
            {
                if (list[j] == "\r")
                {
                    continue;
                }
                for (int i = 0; i <= a; i++)
                {
                    if (j == temp[i])
                        j++;
                }
                for (int k = j + 1; k < list.Count; k++)
                {
                    String[] characterArray1 = new String[list[j].Length];
                    String[] characterArray2 = new String[list[k].Length];
                    if (list[j].ToString().Length == list[k].ToString().Length)
                    {
                        for (int i = 0; i < list[j].Length; i++)
                        {
                            characterArray1[i] = list[j].Substring(i, 1);
                            characterArray2[i] = list[k].Substring(i, 1);
                            if (characterArray1[i] == characterArray2[i])
                            {
                                count++;
                            }
                        }
                        if (count >= 3)
                        {
                            if (resultList.Contains(list[j]))
                            {
                                resultList.Add(list[k]);
                                resultList.Add("");
                            }
                            else
                            {
                                resultList.Add(list[j]);
                                resultList.Add(list[k]);
                                resultList.Add("");
                            }
                        }
                        temp[a] = k;
                        a++;
                    }
                    else
                    {
                        int m = 0;
                        int n = 0;
                        for (m = 0; m < list[j].Length; m++)
                        {
                            for (n = 0; n < list[k].Length; n++)
                            {
                                characterArray1[m] = list[j].Substring(m, 1);
                                characterArray2[n] = list[k].Substring(n, 1);
                                if (characterArray1[m] == characterArray2[n])
                                {
                                    count++;
                                }
                            }
                        }
                        if (count >= 2)
                        {
                            if (resultList.Contains(list[j]))
                            {
                                resultList.Add(list[k]);
                            }
                            else
                            {
                                resultList.Add(list[j]);
                                resultList.Add(list[k]);
                            }
                        }
                        temp[a] = k;
                        a++;
                        //resultList = preSection_notEqual(list);
                    }
                }
            }
            return resultList;
        }
        #endregion

        #region 整段

        public List<String> wholeSection(String allTxt)
        {
            String[] sectionArray = allTxt.Split('\n');
            //resultList.Add(sectionArray[2]);
            int[] temp = new int[sectionArray.Length];
            int a = 0;
            temp[0] = -1;
            for (int i = 0; i < sectionArray.Length; i++)
            {
                if (sectionArray[i] == "\r")
                {
                    continue;
                }
                for (int m = 0; m <= a; m++)
                {
                    if (i == temp[m])
                        i++;
                }
                for (int j = i + 1; j < sectionArray.Length; j++)
                {
                    if (sectionArray[i].Length == sectionArray[j].Length)
                    {
                        if (resultList.Contains(sectionArray[i]))
                        {
                            resultList.Add(sectionArray[j]);
                            resultList.Add("");
                        }
                        else
                        {
                            resultList.Add(sectionArray[i]);
                            resultList.Add(sectionArray[j]);
                            resultList.Add("");
                        }
                        temp[a] = j;
                        a++;
                    }
                }
            }
            return resultList;
        }
        #endregion
    }
}
