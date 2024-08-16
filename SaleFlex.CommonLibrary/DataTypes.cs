using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.CommonLibrary
{
    /// <summary>
    /// Simple attribute class for storing String Values
    /// </summary>
    public class StringValueAttribute : Attribute
    {
        private string m_strValue;

        /// <summary>
        /// Creates a new <see cref="StringValueAttribute"/> instance.
        /// </summary>
        /// <param name="value">Value.</param>
        public StringValueAttribute(string prm_strValue)
        {
            m_strValue = prm_strValue;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value></value>
        public string strValue
        {
            get { return m_strValue; }
        }
    }

    /// <summary>
    /// Simple attribute class to point out Text values
    /// </summary>
    public class TextValueAttribute : Attribute
    {
        /// <summary>
        /// Creates a new <see cref="TextValueAttribute"/> instance.
        /// </summary>
        /// <param name="value">Value.</param>
        public TextValueAttribute()
        {
        }
    }

    /// <summary>
    /// Simple attribute class to point out Text values
    /// </summary>
    public class ByteValueAttribute : Attribute
    {
        /// <summary>
        /// Creates a new <see cref="ByteValueAttribute"/> instance.
        /// </summary>
        /// <param name="value">Value.</param>
        public ByteValueAttribute()
        {
        }
    }

    /// <summary>
    /// Simple attribute class to point out Description values
    /// </summary>
    public class DescriptionValueAttribute : Attribute
    {
        private string m_strDescription;

        /// <summary>
        /// Creates a new <see cref="DescriptionValueAttribute"/> instance.
        /// </summary>
        /// <param name="prm_strDescription">prm_strDescription.</param>
        public DescriptionValueAttribute(string prm_strDescription)
        {
            m_strDescription = prm_strDescription;
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value></value>
        public string strDescription
        {
            get { return m_strDescription; }
        }
    }
}
