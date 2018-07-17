


/* Registry of all the routes our app uses */
public static class ServiceRegistry
{


// modified roots
 public static string STAFF_OTP = "staff/otp";
 public static OTP_VALIDATE:string = 'otp/validate';
 public static WHOMAI:string = 'starlogin/whoami'
 public static ADMIN_LOGIN_TOKEN : string = 'starlogin/token'
 public static ADMIN_LOGIN:string = 'starlogin/login';
 public static GET_MY_SCHOOL :string = 'school/enterprise'
 public static ADD_MY_SCHOOL :string = 'school/insert'





// old roots
  /* STAR LOGIN */
  public static USER_NORM_REG:string = 'starlogin/classicregister'
  public static USER_INIT_FORGOTPWD:string = 'starlogin/forgotpassword/initiate'
  public static USER_PROC_FORGOTPWD:string = 'starlogin/forgotpassword/reset'
  public static USER_SOC_REG:string = 'starlogin/sociallogin'
  public static USER_LOGIN:string = 'starlogin/classiclogin'
  public static USER_RESEND_EMAIL:string = 'starlogin/resend/email'
  public static USER_CHANGE_PWD:string = 'starlogin/password/change'
  public static USER_DEVICE_REG:string = 'deviceRegistry/push'

  /* USER SERVICE */
  public static USER_WHOMAI:string = 'users/whoami'
  public static DO_I_EXIST:string = 'users/doiexist'
  public static EDIT_PROFILE:string = 'users/editprofile'
  public static UPLOAD_PROFILE:string = 'users/uploadprofile'
  public static UPLOAD_COVER:string = 'users/uploadcover'

  /* FEEDBACK SERVICE */
  public static ADD_FEEDBACK:string = 'feedback/insert'
  public static GET_FEEDBACK:string = 'feedback/get'
  public static ALLOWED_FEEDBACK:string = 'feedback/allowed'



   // old
   public static STAFF_REG : string = 'staff/insert'
   public static STAFF_LOGIN:string = 'staff/classiclogin';
  
   public static CURRENT_USER:string = 'staff/current';
   public static STAFF_EXIST:string = 'staff/isexist'
   public static OTP_SEND:string = 'staff/sendotp';
   
   public static STAFF_WHOMAI:string = 'staff/whoami'
  public static STAFF_EDIT_PROFILE:string = 'staff/editprofile'
  public static STAFF_UPLOAD_PROFILE:string = 'staff/uploadprofile'
  public static STAFF_UPLOAD_COVER:string = 'staff/uploadcover'
  public static STAFF_SOC_REG:string = 'starlogin/sociallogin'
/*Inserting data*/
  public static SCHOOL_REG:string="school/insert"
  public static SCHOOL_FIND_BY_ID:string="school/findbyid"
  public static SCHOOL_EXIST:string = ""
  public static  STUDENT_CLASS_REG: string = "studentClass/insert"
  public static SECTION_REG:string ="section/insert"
  public static STUDENT_REG:string ="student/insert"
  public static CLASS_LEVEL_REG:string ="classLevel/insert"
  public static VENDOR_REG:string="vendor/insert"
  public static MEAL_REG:string="meals/insert"
  /*Deleting data*/
  public static SCHOOL_DELETE :string = "school/delete"
  public static STUDENT_DELETE :string ="student/delete"
  public static STUDENT_CLASS_DELETE: string="studentClass/delete"
  public static SECTION_DELETE : string = "section/delete"
  public static CLASS_LEVEL_DELETE :string= "classLevel/delete"

  /*Enterprise Service*/
   
    public static ENTERPRISE_REG : string = 'enterprise/classicregister'
    public static ENTERPRISE_WHOMAI:string = 'enterprise/whoami'
    public static SCHOOL_ENTERPRISE:string = 'school/enterprise'
    public static STAFF_ENTERPRISE:string = "staff/enterprise"
    public static ENTERPRISE_VENDOR:string = "vendor/enterprise"
   /*Get All*/
   public static GET_ALL_STAFF :string = 'staff/findbyid'

   public static GET_ALL_CLASS :string = 'studentClass/findbypage'
   public static GET_ALL_SECTION :string = 'section/findbypage'
   public static GET_ALL_PARENTS :string = 'users/findbypage'
   public static GET_ALL_STUDENTS :string = 'student/findbypage'
   public static GET_ALL_VENDORS :string = 'vendor/findbycondition'
   public static GET_ALL_MEALS :string = 'meals/findbycondition'
   
   
   
 }

export enum HttpProtocol
{
    get,
    post
}




@Injectable()
export class ServiceProxy 
{

            /* Event Emitters */
            public HTTPError: EventEmitter<any> = new EventEmitter();
            public networkError: EventEmitter<any> = new EventEmitter();
            public deviceToken="";
     
            private  base_url = 'https://localhost:8443'; 
            

            constructor (private  http:Http, private transfer: FileTransfer) {  this.HTTPError = new EventEmitter(); }

            public SetDeviceToken(token)
            {
                this.deviceToken = token;
            }

            
        
            public Request(route:ServiceRegistry, data : any , protocol:HttpProtocol)
            {
                
                let url : string = this.FormURI(route);
                let headers = new Headers();
                this.createAuthorizationHeader(headers);

                if(this.deviceToken!=null && data!=null) data.deviceToken = this.deviceToken;

                if(protocol==HttpProtocol.get)
                {
                    let value = this.http.post(url , data , {headers: headers})
                                .map(this.extractData)
                                .catch(this.handleError); 

                    return value;
                }
                else
                {
                    let value = this.http.post(url , data , {headers: headers})
                                .map(this.extractData)
                                .catch(this.handleError);
                    console.log(JSON.stringify(headers))
                    return value;
                }
            }


            public LoadRemotefile(route:ServiceRegistry)
            {
                let url = this.FormURI(route);
                let headers = new Headers();
                this.createAuthorizationHeader(headers);

               return this.http.post(url , null , {headers: headers}).map(res=>res.json());

            }



            public Upload(route:ServiceRegistry, data:any)
            {
                let url = this.FormURI(route);
                let headers = new Headers();
                this.createAuthorizationHeader(headers);
                // File for Upload
                var targetPath = data;
                var options: FileUploadOptions = { fileKey: 'image', 
                                                  chunkedMode: false, 
                                                  mimeType: 'multipart/form-data', 
                                                  headers: headers,
                                                  params: { 'desc': "profile"}};
                const fileTransfer: FileTransferObject = this.transfer.create();
                // Use the FileTransfer to upload the image
                return fileTransfer.upload(targetPath, url, options); 
            }

            private  extractData(res: Response) 
            {             
                   

                    let body = res.json();
                    return body || { };
            }

            
            private  handleError = (error: Response | any) =>
            {
                    
                    // inform the user 
                    let errorCode=100;
                    let errMsg: string;

                    if (error instanceof Response) 
                    {
                        let o = JSON.parse(JSON.stringify(error));
                        errorCode = o.status;
                    } 
                    
                    this.HTTPError.emit({error:errorCode});
                    return Observable.throw(errMsg);
            }

            
            public   FormURI(route:ServiceRegistry):string
            {
                return this.base_url+"/"+route;
            }

            /* we have to add a header to our HTTP requests */
            private  createAuthorizationHeader(headers: Headers) 
            {
                    let token =  TokenHelper.GetLoginToken();
                    headers.append('Authorization', 'Basic ' +token); 
            }


}