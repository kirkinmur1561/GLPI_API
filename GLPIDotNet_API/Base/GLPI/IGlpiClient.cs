using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GLPIDotNet_API.Base.Request;

namespace GLPIDotNet_API.Base.GLPI
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGlpiClient:IGlpi,IEquatable<IGlpiClient>
    {        
        public bool IsClone { get; }
        
        /// <summary>
        /// Очередь запросов
        /// </summary>
        Queue<ClientRequest> QueueRequest { get; }

        /// <summary>
        /// 
        /// </summary>
        CancellationTokenSource StopMotor { get; }

        /// <summary>
        /// Обработчик запросов
        /// </summary>
        void Motor();       


        new virtual async Task Close()
         {
             await ((IGlpi)this).Close();
            
            QueueRequest?.Clear();
            StopMotor?.Cancel();
            StopMotor?.Dispose();            
        }
    }
}
