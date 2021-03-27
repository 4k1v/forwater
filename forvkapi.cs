using System;
using VkNet;
using System.Threading.Tasks;
using System.Threading;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Enums.Filters;

class myclass
{
    public  string[] lastmes= new string[10];
    public  void auf(VkApi a)
     {
            a.Authorize(new ApiAuthParams
            {
                AccessToken = "ee30968b9e174e7d225db9b7f9ce3bffcb469104de06a3ded774dbd1c72510abfe974532f438346c752ca"
            });
     }
     public  void sendmes(VkApi a,string txt)
        {   var rnd = new Random();
            a.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
            {   RandomId =rnd.Next(1,200),
                UserId =398152939,
                Message= txt

            });
        }
       public   void getmes(VkApi a)
        {
                var mes = a.Messages.GetHistory(new MessagesGetHistoryParams
                {   UserId = 398152939,
                PeerId = 398152939,
                Offset =0,
                Reversed =false,

                });
                int i =0;
                foreach (var item in mes.Messages)
                {   
                   // Console.WriteLine(item.Text);
                    
                    if(i<10)
                    {
                        lastmes[i]=item.Text;
                    }

                    i++;
                    
                    
                }
                
                
        }
         public void checkda(VkApi a) 
         {
              getmes(a);
                string norep="";
                if (lastmes[0]=="да")
                {  
                    if (norep !=lastmes[0])
                    {
                        sendmes(a,"правода");
                        norep = lastmes[0];
                    }
                };
                Thread.Sleep(5000);
         }
         public  void userauf(VkApi a,string log,string pas)
         {   
             a.Authorize(new ApiAuthParams
             {
                ApplicationId = 7617413,
                Login = log,//"89818429250"
                Password = pas,//"cheken381"
                Settings = Settings.All,
                
                 

             });
         }

}