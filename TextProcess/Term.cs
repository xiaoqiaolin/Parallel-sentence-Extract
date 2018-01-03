using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProcess
{
    /// <summary>
    /// 词项
    /// </summary>
    class Term
    {
        /// <summary>
        /// 词在词表中的索引(在线性词表中的序号)
        /// </summary>
        public int index;

        /// <summary>
        /// 词出现过的文档数(在多少篇文章出现过)
        /// </summary>
        public int docNum;


        /// <summary>
        /// 
        /// </summary>
        public Term(int index)
        {
            this.index = index;
        }
    }
}
