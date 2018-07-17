
export class TokenHelper
{

        private  static login_identifer:string = "jinglejangle";

        public static SaveLoginToken(data:string)
        {
            console.log("Saving Token")
            window.localStorage.setItem(this.login_identifer, data);
        }

        public static GetLoginToken()
        {
            return window.localStorage.getItem(this.login_identifer);
        }

        public static RemoveLoginToken()
        {
            alert("Remove Login Token :: "+ "I am called "+ this.login_identifer)
            window.localStorage.removeItem(this.login_identifer);
        }


        

}