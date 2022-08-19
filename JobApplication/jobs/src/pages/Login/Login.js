import React from 'react'
import "./Login.css"
import { useState } from 'react';
import toast, { Toaster } from "react-hot-toast";
import axios from 'axios';
import image from "../../images/iş.jpeg";
function Login() {

    const success = () =>
        toast.success("Giriş Başarılı!", {
            position: "bottom-center",
        });

    const err = () =>
        toast.error("Girdiğiniz bilgiler yanlış!", {
            position: "bottom-center",
        });


    const [formValue, setformValue] = useState({
        email: "",
        password: "",
        userType: "",
    });

    const handleChange = (event) => {
        setformValue({
            ...formValue,
            [event.target.name]: event.target.value,
        });
    };

    console.log(formValue);
    const handleSubmit = async (e) => {
        e.preventDefault();

        let loginFormData = new FormData();
        loginFormData.append("email", formValue.email);
        loginFormData.append("password", formValue.password);
        loginFormData.append("userType", formValue.userType);
        axios
            .post("https://localhost:5001/Logins", formValue)
            .then((res) => {
                success();
                localStorage.clear();
                localStorage.setItem("email",formValue.email);
                window.location.href = "/homepage";
            })
            .catch((err) => {
                if (err.response.status === 400 || err.response.status === 404 || err.response.status === 500) {
                    alert("Girdiğiniz bilgiler yanlış!");
                    err();
                }
                err();
            })
    }

    return (
        <div className="Login">
            <form onSubmit={handleSubmit}>
                <div className="out-box">
                    <img src={image} alt="" />
                    <h4>Lütfen Bilgilerinizi Eksiksiz Biçimde Giriniz</h4>

                    <div className="card">
                        <span>Email</span>
                        <input className="input " type="text" placeholder="abc@example.com"
                            name="email"
                            onChange={handleChange}
                            values={formValue.email} />
                    </div>
                    <div className="card">
                        <span>Şifre</span>
                        <input type="text" placeholder="En az 8 Karakter"
                            name="password"
                            onChange={handleChange}
                            values={formValue.password} />
                    </div>
                    <div className="card">
                        <span>Kullanıcı Türü</span>
                        <select name="userType" onChange={handleChange}>
                            <option value="employer" >İş Veren</option>
                            <option value="worker">Çalışan</option>
                        </select>
                    </div>

                    <div className="submit">
                        <button>Giriş Yap</button><br />
                        <span>Henüz kayıt olmadın mı?</span>
                        <a href="http://localhost:3000/signup">Yeni Hesap Oluştur</a>
                    </div>
                </div>
            </form>

            <Toaster
                position="bottom-center"
                toastOptions={{
                    success: {
                        duration: 10000,
                        theme: {
                            primary: "green",
                            secondary: "black",
                        },
                    },
                }}
            />
        </div >
    )
}

export default Login