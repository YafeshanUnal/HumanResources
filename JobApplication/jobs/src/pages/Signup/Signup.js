import React, { useState } from 'react';
import "./Signup.css";
import image from '../../images/download.jpeg';
import axios from 'axios';

function Signup() {

    const [formValue, setformValue] = useState({
        name: "",
        surName: "",
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

    const handleSubmit = (event) => {
        event.preventDefault();

        let loginFormData = new FormData();
        loginFormData.append("name", formValue.name);
        loginFormData.append("surName", formValue.surName);
        loginFormData.append("email", formValue.email);
        loginFormData.append("password", formValue.password);
        loginFormData.append("userType", formValue.userType);

        axios
            .post("https://localhost:5001/Signups", formValue)
            .then((res) => {
                alert("Kayıt Başarılı!");
                window.location.href = "/";
            })
            .catch((err) => {
                if (err.response.status === 400 || err.response.status === 404 || err.response.status === 500) {
                    alert("Girdiğiniz bilgiler yanlış!");
                }
            })





    }


    return (
        <div className="Signup">

            <form onSubmit={handleSubmit}>
                <div className="out-box">
                    <img src={image} alt="" />
                    <h4>Lütfen Bilgilerinizi Eksiksiz Biçimde Giriniz</h4>
                    <div className="card">
                        <span>Adınız</span>
                        <input type="text" placeholder="Ad"
                            name="name"
                            onChange={handleChange}
                            values={formValue.name} />
                    </div><div className="card">
                        <span>Soyadınız</span>
                        <input type="text" placeholder="Soy Ad"
                            name="surName"
                            onChange={handleChange}
                            values={formValue.surName} />
                    </div>
                    <div className="card">
                        <span>Email</span>
                        <input className="input-" type="text" placeholder="abc@example.com"
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
                            <option value="employer">İş Veren</option>
                            <option value="worker">Çalışan</option>
                        </select>
                    </div>

                    <div className="submit">
                        <button>Kayıt Ol</button>
                    </div>
                </div>
            </form>


        </div>
    )
}

export default Signup;