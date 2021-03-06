using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Class;
using System.Numerics;
using Microsoft.Extensions.Configuration;
using API.Models;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly TR3SDETR3SContext _context;
        public ResultController(TR3SDETR3SContext context)
        {
            _context = context;
        }

        [HttpPost]
        public Result result(Request request)
        { 
            //se usa BigInteger porque los últimos números del array son demasiado grandes para un UInt64
            BigInteger[] fibonacci = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610,
                987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 
                317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 
                39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733, 1134903170, 1836311903, 
                2971215073, 4807526976, 7778742049, 12586269025, 20365011074, 32951280099, 53316291173, 86267571272, 
                139583862445, 225851433717, 365435296162, 591286729879, 956722026041, 1548008755920, 2504730781961, 
                4052739537881, 6557470319842, 10610209857723, 17167680177565, 27777890035288, 44945570212853, 
                72723460248141, 117669030460994, 190392490709135, 308061521170129, 498454011879264, 806515533049393, 
                1304969544928657, 2111485077978050, 3416454622906707, 5527939700884757, 8944394323791464, 
                14472334024676221, 23416728348467685, 37889062373143906, 61305790721611591, 99194853094755497, 
                160500643816367088, 259695496911122585, 420196140727489673, 679891637638612258, 
                1100087778366101931, 1779979416004714189, 2880067194370816120, 4660046610375530309, 
                7540113804746346429, 12200160415121876738, BigInteger.Parse("19740274219868223167"), 
                BigInteger.Parse("31940434634990099905"), 
                BigInteger.Parse("51680708854858323072"), BigInteger.Parse("83621143489848422977"), 
                BigInteger.Parse("135301852344706746049"), BigInteger.Parse("218922995834555169026") };


            BigInteger n1 = BigInteger.Parse(request.n1);
            BigInteger n2 = BigInteger.Parse(request.n2);

            BigInteger total = n1 + n2;

            var result = new Result();
            result.result = total.ToString();


            //se añade el resgistro de la operación a la base de datos
            var operation = new Operation();
            operation.N1 = n1.ToString();
            operation.N2 = n2.ToString();
            operation.Result = total.ToString();
            _context.Operations.Add(operation);
            _context.SaveChanges();


            //se verifica que sí pertenezca a la serie de fibonacci
            for(int i = 0; i < 100; i++)   
            {
                if(total == fibonacci[i])
                {
                    result.fibonacci = true;
                    return result;
                }
            }

            //nota: El valor por defecto de result.fibo es false (ver Modelo)
            return result;

        }
    }
}
