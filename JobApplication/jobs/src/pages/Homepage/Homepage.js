import axios from 'axios'
import React, { useEffect, useState } from 'react'
import toast, { Toaster } from "react-hot-toast";
import "./Homepage.css"

function Homepage() {

    const [advert, setAdvert] = useState([]);
    const [filter, setFilter] = useState({
        department: "",
        location: "",
        experience: 0,
    });
    const filtered = advert.filter(advert => {
        return advert.department === filter.department && advert.location === filter.location && advert.experience === filter.experience;
    });

    const successApplication = () =>
        toast.success("Başvuru Başarılı!", {
            position: "bottom-center",
            duration: 3000,

        });

    const [formValue, setformValue] = useState({
        email: localStorage.getItem("email"),
    });


    const handleChange = (event) => {
        setFilter({
            ...filter,
            [event.target.name]: event.target.value,
        });
    }



    useEffect(() => {
        axios
            .get("https://localhost:5001/Adverts")
            .then((res) => {
                setAdvert(res.data);
            })
    }, []);
    console.log(advert);




    return (

        <div className="Homepage">
            <div className="navbar">
                <a href="/homepage" className="home">Anasayfa</a>
                <a href="/advert" className="create-advert">İlan Oluştur</a>
            </div>

            <div className="filter">
                <select name="location" onChange={handleChange}>
                    <option value="">İl Seçiniz</option>
                    <option value="İstanbul" >İstanbul</option>
                    <option value="İzmir" >İzmir</option>
                    <option value="Ankara" >Ankara</option>
                    <option value="Konya" >Konya</option>
                </select>
                <select name="experience" onChange={handleChange}>
                    <option value="">Deneyim Süresi</option>
                    <option value="1">1 Yıl</option>
                    <option value="2">2 Yıl</option>
                    <option value="3">5 Yıl</option>
                    <option value="4">10 Yıl</option>
                </select>

                <select name="department" onChange={handleChange}>
                    <option value="">Departman</option>
                    <option value="IT">Bilgi İşlem</option>
                    <option value="Software">Yazılım</option>
                    <option value="HR">İnsan Kaynakları</option>
                </select>
                <button onClick={
                    () => {
                        let loginFormData = new FormData();
                        loginFormData.append("department", filter.department);
                        loginFormData.append("location", filter.location);
                        loginFormData.append("experience", filter.experience);
                        console.log(filter.location + filter.experience + filter.department);
                        axios
                            .post(`https://localhost:5001/Adverts/filter`, filter)
                            .then((res) => {
                                setAdvert(res.data);
                            })
                        console.log(advert);

                    }
                }>Filtrele</button>

            </div>
            <div className="advert">
                <div className="row">
                    {advert.map(adverts => {
                        return <div key={adverts.advertId} >
                            <div className="card">
                                <div className="card-header" key={adverts.advertId}  >
                                    <h6>İlan Numarası {adverts.advertId}</h6>
                                    <h6>İlan Açıklaması {adverts.description}</h6>
                                </div>
                                <div className="card-body">
                                    <p>Bölüm: <span>{adverts.department}</span></p>
                                    <p>Konum: {adverts.location}</p>
                                    <p>Deneyim: {adverts.experience} yıl</p>
                                    <p>Ünvan: {adverts.workTitle}</p>
                                </div>

                                <button className="btn" onClick={
                                    () => {
                                        let loginFormData = new FormData();
                                        loginFormData.append("email", localStorage.getItem("email"));
                                        axios
                                            .post(`https://localhost:5001/Applications/${adverts.advertId}`, formValue)
                                            .then((res) => {
                                                console.log(res);
                                                successApplication();
                                            })

                                    }
                                }>Başvur</button>
                            </div>
                        </div>
                    })}
                </div>
            </div>

            <Toaster
                position="top-center"
                toastOptions={{
                    success: {
                        duration: 3000,
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
export default Homepage;
