﻿using GrpcServer.Data;
using Microsoft.AspNetCore.Http;
using ProtoBuf.Grpc;
using Share;
using ISession = NHibernate.ISession;


namespace GrpcServer.Repository
{
    public class LopHocRepository : ILopHocRepository
    {
        public List<LopHoc> GetListLopHoc(Empty request)
        {
            try
            {
                List<LopHoc> lh;
                using (NHibernate.ISession session = FluentNHibernateHelper.GetSession())
                {
                    lh = session.Query<LopHoc>().ToList();

                }
                return lh;

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public  Boolean UpdateLopHoc(List<LopHoc> lophoc)
        {

            using (var session = FluentNHibernateHelper.GetSession())
            {
                using (var tran = session.BeginTransaction())
                {
                        try
                        {
                        foreach (var item in lophoc)
                        {
                            session.Update(item);

                            tran.Commit();
                        }
                            
                            return true;
                        }
                        catch (Exception exx)
                        {
                            tran.Rollback();
                            throw exx;
                            return false;
                        }
                   
                }
            }
        }

        public LopHoc GetLopHocByID(int id)
        {
            LopHoc lh;
            using (ISession session = FluentNHibernateHelper.GetSession())
            {
                using (var tran = session.BeginTransaction())
                    try
                    {
                        lh = session.Get<LopHoc>(id);
                        return lh;
                    }
                    catch (Exception exx)
                    {
                        tran.Rollback();
                        throw exx;
                        return lh;
                    }
            }


        }

        public Boolean AddLopHoc(List<LopHoc> lophoc)
        {

            using (var session = FluentNHibernateHelper.GetSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    try
                    {
                        foreach(var item in lophoc)
                        {
                            session.Save(item);

                            tran.Commit();
                        }
                        return true;
                    }
                    catch (Exception exx)
                    {
                        tran.Rollback();
                        throw exx;
                        return false;
                    }
                }
            }
        }

        public void DeleteLopHoc(LopHoc lophoc)
        {
            using (var session = FluentNHibernateHelper.GetSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    session.Delete(lophoc);
                    tran.Commit();
                }
            }
        }
    }
}
