using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using O2Micro.Cobra.Communication;
using O2Micro.Cobra.Common;
using System.IO;

namespace O2Micro.Cobra.Wizards
{
    internal class TrimDEMBehaviorManage : DEMBehaviorManageBase
    {

        #region 基础服务功能设计
        public override UInt32 Command(ref TASKMessage msg)
        {
            Parameter param = null;
            ParamContainer demparameterlist = null;
            UInt32 ret = LibErrorCode.IDS_ERR_SUCCESSFUL;

            demparameterlist = msg.task_parameterlist;
            if (demparameterlist == null) return ret;
            switch ((ElementDefine.COMMAND)msg.sub_task)
            {
                case ElementDefine.COMMAND.TRIM_SLOPE_TRIMMING:

                    Preparation();

                    for (ushort i = 0; i < demparameterlist.parameterlist.Count; i++)
                    {
                        param = demparameterlist.parameterlist[i];
                        param.sphydata = String.Empty;
                    }

                    for (ushort code = 0; code < 16; code++)
                    {
                        WriteSlopeCode(code);

                        ret = ReadAvrage(ref msg);
                        if (ret != LibErrorCode.IDS_ERR_SUCCESSFUL) return ret;

                        for (ushort i = 0; i < demparameterlist.parameterlist.Count; i++)
                        {
                            param = demparameterlist.parameterlist[i];
                            param.sphydata += param.phydata.ToString() + ",";
                        }
                    }
                    break;
                case ElementDefine.COMMAND.TRIM_OFFSET_TRIMMING:

                    Preparation();

                    for (ushort i = 0; i < demparameterlist.parameterlist.Count; i++)
                    {
                        param = demparameterlist.parameterlist[i];
                        param.sphydata = String.Empty;
                    }

                    for (ushort code = 0; code < 16; code++)
                    {
                        WriteOffsetCode(code);

                        ret = ReadAvrage(ref msg);
                        if (ret != LibErrorCode.IDS_ERR_SUCCESSFUL) return ret;

                        for (ushort i = 0; i < demparameterlist.parameterlist.Count; i++)
                        {
                            param = demparameterlist.parameterlist[i];
                            param.sphydata += param.phydata.ToString() + ",";
                        }
                    }
                    break;
            }
            return ret;
        }

        private void WriteOffsetCode(ushort code)
        {
            throw new NotImplementedException();
        }

        private void Preparation()
        {
            throw new NotImplementedException();
        }

        private uint ReadAvrage(ref TASKMessage msg)
        {
            throw new NotImplementedException();
        }

        private void WriteSlopeCode(ushort code)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}