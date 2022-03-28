using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestWebAPI_list_.Models;

namespace TestWebAPI_list_.Controllers

{
    public class SupplierController : ApiController
    {
    public static List<Supplier> listofsuppliers = new List<Supplier>();

        // GET api/values
        //public HttpResponseMessage GetSupplier()
        //{
        //    if (listofsuppliers.Count == 0)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NoContent, "The list of suppliers is empty.");
        //    }
        //    else return Request.CreateResponse(HttpStatusCode.OK);
        //}

        // GET api/values/5
        //public HttpResponseMessage GetSupplierById(int id)
        //{
        //    var member =listofsuppliers.FirstOrDefault(element => element.Id == id);
        //    if (member != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK,member.ToString());
        //    }
        //    else
        //        return Request.CreateResponse(HttpStatusCode.NotFound,"Supplier index does not exist.");
        //}

        // POST api/values
        //public HttpResponseMessage PostSupplier(Supplier supplier)
        //{
        //    if (listofsuppliers.Count == 0)
        //    {
        //        supplier.Id = 1;
        //        listofsuppliers.Add(supplier);
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    else 
        //    {
        //        supplier.Id = listofsuppliers.Last().Id + 1;
        //        listofsuppliers.Add(supplier);
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //}

        // PUT api/values/5
        //public HttpResponseMessage PutSupplier(Supplier supplier)
        //{
        //    var member = listofsuppliers.FirstOrDefault(element => element.Id == supplier.Id);
        //    if (member != null)
        //    {
        //        member.Name = supplier.Name;
        //        member.Adress = supplier.Adress;
        //        member.Iban = supplier.Iban;
        //       return Request.CreateResponse(HttpStatusCode.OK);
        //    }

        //    else
        //        return Request.CreateResponse(HttpStatusCode.NotFound, "Supplier index does not exist.");
        //}

        // DELETE api/values/5
        //public HttpResponseMessage DeleteSuppliers(int id)
        //{
        //    var member = listofsuppliers.FirstOrDefault(element => element.Id == id);
        //    if (member != null)
        //    {
        //        listofsuppliers.Remove(member);
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    else
        //        return Request.CreateResponse(HttpStatusCode.NotFound, "Supplier index does not exist.");
        //}
    }
}
