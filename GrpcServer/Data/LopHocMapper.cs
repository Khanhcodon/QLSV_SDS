using System.Security.Claims;
using Share;

namespace GrpcServer.Data
{
    public class LopHocMapper
    {
        public LopHocGrpc ClassToClassGrpc(LopHoc lopHoc)
        {
            LopHocGrpc lopHocGrpc = new LopHocGrpc();
            lopHocGrpc.ClassId = lopHoc.ClassId.ToString();
            lopHocGrpc.ClassName = lopHoc.ClassName;
            lopHocGrpc.ObjectName = lopHoc.ObjectName;
            lopHocGrpc.Status = lopHoc.Status;
            return lopHocGrpc;
        }
        public LopHoc ClassGrpcToClass(LopHocGrpc lopHocGrpc)
        {
            LopHoc lopHoc = new LopHoc();
            lopHoc.ClassId = int.Parse(lopHocGrpc.ClassId);
            lopHoc.ClassName = lopHocGrpc.ClassName;
            lopHoc.ObjectName = lopHocGrpc.ObjectName;
            lopHoc.Status = lopHocGrpc.Status;
            return lopHoc;
        }
    }
}
