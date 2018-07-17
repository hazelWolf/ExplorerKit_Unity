
export class AuthenticationService 
{
    public currentUser:Object;
    constructor(private proxy: S.ServiceProxy){}

    public LogoutTrigger:EventEmitter<any> = new EventEmitter<any>();



    getLoginToken(payload):Observable<R.IResponse>
    {
        //alert(JSON.stringify(payload));
        let r:S.ServiceRegistry = S.ServiceRegistry.ADMIN_LOGIN_TOKEN;
        let p: S.HttpProtocol = S.HttpProtocol.post;
        let response:any;
        //console.log(r)
        console.log(p)
        return this.proxy.Request(r,payload,p); 
    }

    whomai():Observable<R.IResponse>
    {
        let r:S.ServiceRegistry = S.ServiceRegistry.WHOMAI;
        let p: S.HttpProtocol = S.HttpProtocol.post;
        let response:any;
        //console.log(r)
        console.log(p)
        return this.proxy.Request(r,null,p); 
    }




    /////////////////// OLD 


    // retruns the currently logged in user
    whomaiEnterprise():Observable<R.IResponse>
    {
        let r:S.ServiceRegistry = S.ServiceRegistry.ENTERPRISE_WHOMAI
        let p: S.HttpProtocol = S.HttpProtocol.post;
        let response:any;
        //console.log(r)
        console.log(p)
        return this.proxy.Request(r,null,p); 
    }
    whomaiStaff():Observable<R.IResponse>
    {
        let r:S.ServiceRegistry = S.ServiceRegistry.STAFF_WHOMAI
        let p: S.HttpProtocol = S.HttpProtocol.post;
        let response:any;
        //console.log(r)
        console.log(p)
        return this.proxy.Request(r,null,p); 
    }
  

    //logs out the user
    logout()
    {
        this.LogoutTrigger.emit();
    }

    // sets the current user
    setCurrentUser(u:IStarlogin)
    {
        console.log(u);
        this.currentUser = u;
    }

    // gets the current staff
    getCurrentUser():IStarlogin
    {
            return this.currentUser;
    }


    // edits the profile of the current user
    editProfile(payload:Object):Observable<R.IResponse>
    {
        let r:S.ServiceRegistry = S.ServiceRegistry.STAFF_EDIT_PROFILE;
        let p: S.HttpProtocol = S.HttpProtocol.post;
        let response:any;
        let data = {payload:payload};
        return this.proxy.Request(r,payload,p); 
    }

    uploadProfile(payload):any
    {
     
        return this.proxy.Upload(S.ServiceRegistry.STAFF_UPLOAD_PROFILE, payload);
    }

    uploadCover(payload):any
    {
        return this.proxy.Upload(S.ServiceRegistry.STAFF_UPLOAD_COVER, payload);
    }

    

    deviceRegister(payload):Observable<R.IResponse>
    {
        let r:S.ServiceRegistry = S.ServiceRegistry.USER_DEVICE_REG;
        let p: S.HttpProtocol = S.HttpProtocol.post;
        let response:any;
        return this.proxy.Request(r,payload,p); 
    }

    initiateForgotPassword(u:Object): Observable<any>
    {
            let r:S.ServiceRegistry = S.ServiceRegistry.USER_INIT_FORGOTPWD;
            let p: S.HttpProtocol = S.HttpProtocol.post;
            return this.proxy.Request(r,u,p);
    }

    processForgotPassword(o:L.OTP): Observable<any>
    {
            let r:S.ServiceRegistry = S.ServiceRegistry.USER_PROC_FORGOTPWD;
            let p: S.HttpProtocol = S.HttpProtocol.post;
            return this.proxy.Request(r,o,p);
    }

    attemptAdminLogin(d:L.AdminAuth): Observable<any>
    {
            let r:S.ServiceRegistry = S.ServiceRegistry.ADMIN_LOGIN;
            let p: S.HttpProtocol = S.HttpProtocol.post;
            console.log("log in enterprise");
            console.log(r);
            return this.proxy.Request(r,d,p);
    }

    

    attemptUserInsertion(d:User): Observable<any>
    {
            let r:S.ServiceRegistry = S.ServiceRegistry.USER_NORM_REG;
            let p: S.HttpProtocol = S.HttpProtocol.post;
            return this.proxy.Request(r,d,p);
    }
    attemptStaffInsertion(d:Staff): Observable<any>
    {
            let r:S.ServiceRegistry = S.ServiceRegistry.STAFF_REG;
            let p: S.HttpProtocol = S.HttpProtocol.post;
            return this.proxy.Request(r,d,p);
    }

    resendEmailVerification(d:L.Registration): Observable<any>
    {
            let r:S.ServiceRegistry = S.ServiceRegistry.USER_RESEND_EMAIL;
            let p: S.HttpProtocol = S.HttpProtocol.post;
            return this.proxy.Request(r,d,p);
    }

        doIExist(d:L.Registration): Observable<any>
        {
                let r:S.ServiceRegistry = S.ServiceRegistry.STAFF_EXIST;
                let p: S.HttpProtocol = S.HttpProtocol.post;
                return this.proxy.Request(r,d,p);
        }
        doesSchoolExist(d:School): Observable<any>
        {
                let r:S.ServiceRegistry = S.ServiceRegistry.SCHOOL_EXIST;
                let p: S.HttpProtocol = S.HttpProtocol.post;
                return this.proxy.Request(r,d,p);
        }
    //For Staff #Tom
        attemptSocialRegistration(d:Staff): Observable<any>
        {
                let r:S.ServiceRegistry = S.ServiceRegistry.STAFF_SOC_REG;
                let p: S.HttpProtocol = S.HttpProtocol.post;
                return this.proxy.Request(r,d,p);
        }
    //For Staff #Tom
        processChangePassword(payload): Observable<any>
        {
                let r:S.ServiceRegistry = S.ServiceRegistry.USER_CHANGE_PWD;
                let p: S.HttpProtocol = S.HttpProtocol.post;
                return this.proxy.Request(r,payload,p);
        }

    

   


}