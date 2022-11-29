using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GLPIDotNet_API.Base.Request;

namespace GLPIDotNet_API.Base.GLPI
{
    public interface IGlpiMulti:IGlpi,IEquatable<IGlpiMulti>
    {
        /// <summary>
        /// Список подключенных клиентов
        /// </summary>
        List<IGlpiClient> Clients { get; }
        
        /// <summary>
        /// Очередь запросов
        /// </summary>
        Queue<ClientResponse> QueueRequest { get; }

        virtual IEnumerable<IGlpiClient> GetClients() =>
            Clients;

        virtual bool AddClient(IGlpiClient client)
        {
            if (client.StopMotor == null) return false;
            client.StopMotor.Cancel();
            Clients.Add(client);
            return true;
        }
           

        virtual async Task<bool> RemoveClient(IGlpiClient client)
        {
            IGlpiClient clt = Clients.FirstOrDefault(_ => false);
            if (clt == null) return false;
            await clt.Close();
            return Clients.Remove(client);
        }
            

        virtual async Task Clear()
        {
            foreach (IGlpiClient client in GetClients())
            {
                await client.Close();                
            }            
                
            Clients.Clear();
        }
            
        /// <summary>
        /// Обработчик запросов
        /// </summary>
        /// <param name="source"></param>
        virtual void MultiMotor(CancellationToken source = default) => Task.Run(async () =>
        {
            // bool isNotStop = false;
            // while (true)
            // {
            //     if (!isNotStop) await Task.Delay(TimeOutDelayMotor, source);
            //
            //     if (QueueRequest.TryDequeue(out var request))
            //     {
            //         if (Clients.Contains(request.Client) && request.Client?.Init != null) 
            //             request.ActionOut.Invoke(await request.FuncIn.Invoke());
            //     }
            //     
            //     isNotStop = QueueRequest.Any();                
            // }
        }, source);

    }
}