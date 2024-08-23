using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaleFlex.Data;

namespace SaleFlex.POS.Manager
{
    public partial class PosManager
    {
        private PosManagerData m_xPosManagerData = new PosManagerData();
        public PosManagerData prop_xPosManagerData
        {
            get
            {
                return m_xPosManagerData;
            }
        }

        private EnumDocumentState m_enumDocumentState = EnumDocumentState.CLOSED;
        public EnumDocumentState prop_enumDocumentState
        {
            get
            {
                return m_enumDocumentState;
            }
        }

        private EnumDocumentType m_enumDocumentType = EnumDocumentType.FiscalReceipt;
        public EnumDocumentType prop_enumDocumentType
        {
            get
            {
                return m_enumDocumentType;
            }
            set
            {
                m_enumDocumentType = value;
            }
        }

        private EnumDocumentResult m_enumDocumentResult;
        public EnumDocumentResult prop_enumDocumentResult
        {
            get
            {
                return m_enumDocumentResult;
            }
        }

        private EnumErrorCode m_enumErrorCode = EnumErrorCode.NONE;
        public EnumErrorCode prop_enumErrorCode
        {
            get
            {
                return m_enumErrorCode;
            }
        }
    }
}
