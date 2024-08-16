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

        private enumDocumentState m_enumDocumentState = enumDocumentState.CLOSED;
        public enumDocumentState prop_enumDocumentState
        {
            get
            {
                return m_enumDocumentState;
            }
        }

        private enumDocumentType m_enumDocumentType = enumDocumentType.FiscalReceipt;
        public enumDocumentType prop_enumDocumentType
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

        private enumDocumentResult m_enumDocumentResult;
        public enumDocumentResult prop_enumDocumentResult
        {
            get
            {
                return m_enumDocumentResult;
            }
        }

        private enumErrorCode m_enumErrorCode = enumErrorCode.NONE;
        public enumErrorCode prop_enumErrorCode
        {
            get
            {
                return m_enumErrorCode;
            }
        }
    }
}
