import React, { useState } from 'react'

import "./Advert.css"
import axios from 'axios';
import { Toaster, toast } from 'react-hot-toast';

// ? İş verenlerin departmanı, konumu, tecrübe düzeyine, iş ünvanı, açıklamasını
// * ve diğer detayları belirterek ilan açabileceği bir portal, 
function Advert() {

    const succesCreate = () =>
        toast.success("İlanınız başarıyla oluşturuldu!", {

        });
    const [formValue, setformValue] = useState({

        email: localStorage.getItem("email"),
        department: "",
        location: "",
        experience: 0,
        workTitle: "",
        description: "",
        detail: "",
    });


    const handleChange = (e) => {
        setformValue({
            ...formValue,
            [e.target.name]: e.target.value,
        });
    }

    const handleSubmit = (e) => {
        e.preventDefault();

        let createAdvertFormData = new FormData();
        createAdvertFormData.append("department", formValue.department);
        createAdvertFormData.append("location", formValue.location);
        createAdvertFormData.append("experience", formValue.experience);
        createAdvertFormData.append("workTitle", formValue.workTitle);
        createAdvertFormData.append("description", formValue.description);
        createAdvertFormData.append("detail", formValue.detail);

        console.log(formValue.department + " " + formValue.location + " " + formValue.experience + " " + formValue.workTitle + " " + formValue.description);

        axios
            .post("https://localhost:5001/Adverts", formValue)
            .then((res) => {
                succesCreate();
            })
            .catch((err) => {
                alert("Hata oluştu!");
            });
    }


    return (
        <div className="Advert">
            <div className="navbar">
                <a href="/homepage" className="home">Anasayfa</a>
                <a href="/advert" className="create-advert">İlan Oluştur</a>
            </div>

            <form action="" onSubmit={handleSubmit}>
                <div className="card">
                    <div className="card-head">
                        <h3>İlan Oluştur</h3>
                    </div>
                    <div className="card-body">
                        <span htmlFor="">Departman</span>
                        <input type="text" name="department" id="" onChange={handleChange} />
                        <span htmlFor="">Konum</span>
                        <input type="text" name="location" onChange={handleChange} />
                        <span htmlFor="">Tecrübe Yılı</span>
                        <input type="number" name="experience" id="" onChange={handleChange} />
                        <span htmlFor="">İş Ünvanı</span>
                        <input type="text" name="workTitle" id="" onChange={handleChange} />
                        <span htmlFor="">İş Açıklaması</span>
                        <input type="text" name="description" id="" onChange={handleChange} />
                        <span htmlFor="">İş Detayı</span>
                        <input type="text" name="detail" id="" />
                    </div>
                    <button>Oluştur</button>


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


        </div>

    )
}

export default Advert