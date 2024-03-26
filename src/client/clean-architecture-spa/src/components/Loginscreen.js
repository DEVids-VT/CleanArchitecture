import axios from "axios";
import { useState } from "react"

export default function Login(){
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const handleUsername = (e) =>{
        setUsername(e.target.value);
    }

    const handlePassword = (e) =>{
        setPassword(e.target.value);
    }
    
    const handleSubmit = (e) =>{
        e.preventDefault();

        axios.post('URL',{
            username: username,
            password: password
        })
        .then(function (response){
            if(response === 200){
                
            }
        })
        .catch(function (error){
            console.log(error);
        })
    }


    return(
        <div className="h-dvh flex justify-around items-center text-center">
            <form onSubmit={handleSubmit}>
                <div className="mb-2">
                    <div><label>Username:</label></div>
                    <input
                        type="text" 
                        value={username} 
                        onChange={handleUsername}
                        className="border-double border-4"
                    />
                </div>
                <div className="my-2">
                    <div><label>Password:</label></div>
                    <input 
                        type="password" 
                        value={password} 
                        onChange={handlePassword}
                        className="border-double border-4"
                    />
                </div>
                <div>
                    <button className="border-double border-4 mt-2">Submit</button>
                </div>
            </form>
        </div>
    )
};