using System;
using System.Collections;

namespace SaleFlex.CommonLibrary
{
    public class StringTokenizer
    {
        private int m_iCurrentIndex;
        private int m_iNumberTokens;
        private ArrayList m_xArrayListTokens;
        private string m_strStringSource;
        private string m_strStringDelimiter;

        /// <summary>
        /// Constructor for StringTokenizer Class.
        /// </summary>
        /// <param name="prm_strStringSource">The Source String.</param>
        /// <param name="prm_strStringDelimiter">The Delimiter String. If a 0 length delimiter is given, " " (space) is used by default.</param>
        public StringTokenizer(string prm_strStringSource, string prm_strStringDelimiter)
        {
            m_xArrayListTokens = new ArrayList(10);
            m_strStringSource = prm_strStringSource;
            m_strStringDelimiter = prm_strStringDelimiter;

            if (prm_strStringDelimiter.Length == 0)
            {
                m_strStringDelimiter = " ";
            }
            vTokenize();
        }

        /// <summary>
        /// Constructor for StringTokenizer Class.
        /// </summary>
        /// <param name="prm_strStringSource">The Source String.</param>
        /// <param name="prm_caStringDelimiter">The Delimiter String as a char[].  Note that this is converted into a single String and
        /// expects Unicode encoded chars.</param>
        public StringTokenizer(string prm_strStringSource, char[] prm_caStringDelimiter)
            : this(prm_strStringSource, new string(prm_caStringDelimiter))
        {
        }

        /// <summary>
        /// Constructor for StringTokenizer Class.  The default delimiter of " " (space) is used.
        /// </summary>
        /// <param name="prm_strStringSource">The Source String.</param>
        public StringTokenizer(string prm_strStringSource)
            : this(prm_strStringSource, "")
        {
        }

        /// <summary>
        /// Empty Constructor.  Will create an empty StringTokenizer with no source, no delimiter, and no tokens.
        /// If you want to use this StringTokenizer you will have to call the NewSource(string s) method.  You may
        /// optionally call the NewDelim(string d) or NewDelim(char[] d) methods if you don't with to use the default
        /// delimiter of " " (space).
        /// </summary>
        public StringTokenizer()
            : this("", "")
        {
        }

        private void vTokenize()
        {
            string strTemporaryStringSource = m_strStringSource;
            string strToken = "";
            m_iNumberTokens = 0;
            m_xArrayListTokens.Clear();
            m_iCurrentIndex = 0;

            if (strTemporaryStringSource.IndexOf(m_strStringDelimiter) < 0 && strTemporaryStringSource.Length > 0)
            {
                m_iNumberTokens = 1;
                m_iCurrentIndex = 0;
                m_xArrayListTokens.Add(strTemporaryStringSource);
                m_xArrayListTokens.TrimToSize();
                strTemporaryStringSource = "";
            }
            else if (strTemporaryStringSource.IndexOf(m_strStringDelimiter) < 0 && strTemporaryStringSource.Length <= 0)
            {
                m_iNumberTokens = 0;
                m_iCurrentIndex = 0;
                m_xArrayListTokens.TrimToSize();
            }
            while (strTemporaryStringSource.IndexOf(m_strStringDelimiter) >= 0)
            {
                //Delimiter at beginning of source String.
                if (strTemporaryStringSource.IndexOf(m_strStringDelimiter) == 0)
                {
                    if (strTemporaryStringSource.Length > m_strStringDelimiter.Length)
                    {
                        strTemporaryStringSource = strTemporaryStringSource.Substring(m_strStringDelimiter.Length);
                    }
                    else
                    {
                        strTemporaryStringSource = "";
                    }
                }
                else
                {
                    strToken = strTemporaryStringSource.Substring(0, strTemporaryStringSource.IndexOf(m_strStringDelimiter));
                    m_xArrayListTokens.Add(strToken);
                    if (strTemporaryStringSource.Length > (m_strStringDelimiter.Length + strToken.Length))
                    {
                        strTemporaryStringSource = strTemporaryStringSource.Substring(m_strStringDelimiter.Length + strToken.Length);
                    }
                    else
                    {
                        strTemporaryStringSource = "";
                    }
                }
            }
            //we may have a string leftover.
            if (strTemporaryStringSource.Length > 0)
            {
                m_xArrayListTokens.Add(strTemporaryStringSource);
            }
            m_xArrayListTokens.TrimToSize();
            m_iNumberTokens = m_xArrayListTokens.Count;
        }

        /// <summary>
        /// Method to add or change this Instance's Source string.  The delimiter will
        /// remain the same (either default of " " (space) or whatever you constructed 
        /// this StringTokenizer with or added with NewDelim(string d) or NewDelim(char[] d) ).
        /// </summary>
        /// <param name="prm_strNewStringSource">The new Source String.</param>
        public void vNewStringSource(string prm_strNewStringSource)
        {
            m_strStringSource = prm_strNewStringSource;
            vTokenize();
        }

        /// <summary>
        /// Method to add or change this Instance's Delimiter string.  The source string
        /// will remain the same (either empty if you used Empty Constructor, or the 
        /// previous value of source from the call to a parameterized constructor or
        /// NewSource(string s)).
        /// </summary>
        /// <param name="prm_strNewDelimiter">The new Delimiter String.</param>
        public void vNewDelimiter(string prm_strNewDelimiter)
        {
            if (prm_strNewDelimiter.Length == 0)
            {
                m_strStringDelimiter = " ";
            }
            else
            {
                m_strStringDelimiter = prm_strNewDelimiter;
            }
            vTokenize();
        }

        /// <summary>
        /// Method to add or change this Instance's Delimiter string.  The source string
        /// will remain the same (either empty if you used Empty Constructor, or the 
        /// previous value of source from the call to a parameterized constructor or
        /// NewSource(string s)).
        /// </summary>
        /// <param name="newDel">The new Delimiter as a char[].  Note that this is converted into a single String and
        /// expects Unicode encoded chars.</param>
        public void vNewDelimiter(char[] prm_caNewDelimiter)
        {
            string strTemporaryStringDelimiter = new String(prm_caNewDelimiter);
            if (strTemporaryStringDelimiter.Length == 0)
            {
                m_strStringDelimiter = " ";
            }
            else
            {
                m_strStringDelimiter = strTemporaryStringDelimiter;
            }
            vTokenize();
        }

        /// <summary>
        /// Method to get the number of tokens in this StringTokenizer.
        /// </summary>
        /// <returns>The number of Tokens in the internal ArrayList.</returns>
        public int iCountTokens()
        {
            return m_xArrayListTokens.Count;
        }

        /// <summary>
        /// Method to probe for more tokens.
        /// </summary>
        /// <returns>true if there are more tokens; false otherwise.</returns>
        public bool bHasMoreTokens()
        {
            if (m_iCurrentIndex <= (m_xArrayListTokens.Count - 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method to get the next (string)token of this StringTokenizer.
        /// </summary>
        /// <returns>A string representing the next token; null if no tokens or no more tokens.</returns>
        public string strNextToken()
        {
            String strReturnString = "";
            if (m_iCurrentIndex <= (m_xArrayListTokens.Count - 1))
            {
                strReturnString = (string)m_xArrayListTokens[m_iCurrentIndex];
                m_iCurrentIndex++;
                return strReturnString;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the Source string of this Stringtokenizer.
        /// </summary>
        /// <returns>A string representing the current Source.</returns>
        public string strStringSource
        {
            get
            {
                return m_strStringSource;
            }
        }

        /// <summary>
        /// Gets the Delimiter string of this StringTokenizer.
        /// </summary>
        /// <returns>A string representing the current Delimiter.</returns>
        public string strDelimiter
        {
            get
            {
                return m_strStringDelimiter;
            }
        }
    }
}
