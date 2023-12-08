import { useState } from "react";
import './Register.css';
import axios from "axios";

function Login() {
    const [username, setUsername] = useState("");
    const [email, setemail] = useState("");
    const [password, setPassword] = useState("");

    var [usernameError, setUsernameError] = useState("");
    var [passwordError, setPasswordError] = useState("");
    var [emailError, setemailError] = useState("");
    var checkUSerData = () => {
        if (username == '') {
            setUsernameError("Username cannot be empty");
            return false;
        }
        return true

        if (password == '')
            setPasswordError("Password Cannot be empty");
        return false;
        return true

        if (email == '')
            setemailError("Email cannot be empty");
        return false;
        return true

    }
    const Login = (event) => {
        event.preventDefault();
        var checkData = checkUSerData();
        if (checkData == false) {
            alert('please check your data')
            return;
        }
        axios.post("http://localhost:5042/api/User/Login", {
            username: username,
            email: email,
            password: password
        })
        .then((userData) => {
            console.log(userData)
            alert('User Login Successfully')
        })
        .catch((err) => {
            console.log(err);
            console.log(err.response);
            alert("Failed");
        })
    }

    return (

        <form className="registerForm">
            <h1 className="heading">Login</h1>
            <label className="form-control">Username</label>
            <input type="text" className="form-control" value={username}
                onChange={(e) => { setUsername(e.target.value) }} />
            <label className="alert alert-danger">{usernameError}</label>
            <label className="form-control">E-Mail</label>
            <input type="text" className="form-control" value={email}
                onChange={(e) => { setemail(e.target.value) }} />
            <label className="alert alert-danger">{emailError}</label>
            <label className="form-control">Password</label>
            <input type="password" className="form-control" value={password}
                onChange={(e) => { setPassword(e.target.value) }} />
            <label className="alert alert-danger">{passwordError}</label>
            <br />
            <button className="btn btn-primary button" onClick={Login}>Login</button>

            <button className="btn btn-danger button">Cancel</button>
        </form>
    );
}

export default Login;