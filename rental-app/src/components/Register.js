import { useState } from "react";
import './Register.css';
import axios from "axios";

function Register(){
    const roles =["User","Admin"];
    const [username,setUsername] = useState("");
    const [password,setPassword] = useState("");
    const [repassword,setrePassword] = useState("");
    const [role,setRole] = useState("");
    const [email,setEmail] = useState("");
    const [phone,setPhone] = useState("");

    var [usernameError,setUsernameError]=useState("");
    var checkUSerData = ()=>{
        if(username=='')
        {
            setUsernameError("Username cannot be empty");
            return false;
        }
           
        if(password=='')
            return false;
        if(role=='Select Role')
            return false;
        return true;
    }
    const signUp = (event)=>{
        event.preventDefault();
        var checkData = checkUSerData();
        if(checkData==false)
        {
            alert('please check yor data')
            return;
        }
        
        axios.post('http://localhost:5042/api/User',{
            
                username: username,
                role:	role,
                password:password,
                email:email,
                phone:phone
            
        })
        .then((userData)=>{
            var token = userData.data.token;
            var username=username.data.username;
            localStorage.setItem("username",username);
            localStorage.setItem("token",token);
            console.log(userData);

        })
        .catch((err)=>{
            console.log(err)
        })
    }
    
    return(
        <form className="registerForm">
            <label className="form-control">Username</label>
            <input type="text" className="form-control" value={username}
                    onChange={(e)=>{setUsername(e.target.value)}}/>
           <label className="alert alert-danger">{usernameError}</label>
            <label className="form-control">Password</label>
            <input type="password" className="form-control" value={password}
                    onChange={(e)=>{setPassword(e.target.value)}}/>
            <label className="form-control">Re-Type Password</label>
            <input type="text" className="form-control" value={repassword}
                    onChange={(e)=>{setrePassword(e.target.value)}}/>
            <label className="form-control">Role</label>
            <select className="form-select" onChange={(e)=>{setRole(e.target.value)}}>
                <option value="select">Select Role</option>
                {roles.map((r)=>
                    <option value={r} key={r}>{r}</option>
                )}
            </select>
            <br/>
            <label className="form-control">Email</label>
            <input type="text" className="form-control" value={email}
                    onChange={(e)=>{setEmail(e.target.value)}}/>
            <label className="form-control">Phone</label>
            <input type="text" className="form-control" value={phone}
                    onChange={(e)=>{setPhone(e.target.value)}}/>
            <button className="btn btn-primary button" onClick={signUp}>Sign Up</button>
            
            <button className="btn btn-danger button">Cancel</button>
        </form>
    );
}

export default Register;