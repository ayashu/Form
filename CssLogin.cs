* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
    font-family: Arial, Helvetica, sans-serif;
}

body {
    min-height: 100vh;
    background: linear-gradient(#2b1005,#7597de);
}

.header {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;

    padding: 30px 100px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    z-index: 100;
}

    .header .logo {
        color: #fff;
        font-weight: 700;
        text-decoration: none;
        font-size: 2em;
        text-transform: uppercase;
        letter-spacing: 2px;
    }

    .header ul {
        display: flex;
        justify-content: center;
        align-items: center;
    }

        .header ul li {
            list-style: none;
            margin-left: 20px;
        }

            .header ul li .bullet {
                text-decoration: none;
                padding: 6px 15px;
                color: #fff;
            }

                .header ul li .bullet:hover {
                    background: white;
                    color: #2b1005;
                    border-radius: 20px;
                }

            .header ul li #HomeLink {
                background: white;
                color: #2b1005;
                border-radius: 20px;
            }

.inline-container {
    display: flex;
    align-items: center;
}

.UsernameIcon
{
    width:25px;
    height:25px;
    margin-right:10px;
}

.EmailText {
    background: none;
    color: white;
    font-size: 14px;
    border: none;
   width:200px;
   outline:none;
}
.logoutbtn{
   background:none;
   text-decoration:none;
   color:white;
   border:none;
   font-size:14px;
}

/*section*/
.section {
    position: relative;
    width: 100%;
    height: 100vh;
    padding: 100px;
    display: flex;
    justify-content: center;
    align-items: center;
}

    .section .img {
        position: absolute;
        top: 0;
        left: 0;
    }

    .section .img1 {
        position: absolute;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
    }

    .section .img3 {
        position: absolute;
        top: 0;
        right: 0;
        width: 70%;
        height: 62%;
        margin-top: 12%;
        margin-left: 40%;
    }

    .section .img4 {
        position: absolute;
        top: 0;
        left: 0;
        width: 100%;
        height: 55%;
        margin-top: 23%;
    }

#text {
    position: absolute;
    color: #fff;
    white-space: nowrap;
    font-size: 5vw;
    z-index: 9;
    margin-bottom: 8%;
}

.btn {
    text-decoration: none;
    display: inline-block;
    padding: 8px 30px;
    border-radius: 40px;
    background: #fff;
    color: #2b1005;
    font-size: 1.5em;
    z-index: 9;
}

.About {
    position: relative;
    padding: 100px;
    background: url("https://external-preview.redd.it/z0RAcfw_Yq6xrzyfGh8dGPj3UCAYHOYjg7-eEnoZNO8.png?width=960&crop=smart&auto=webp&s=fa331ada1bff140c44b478cda6acdee780771cd2");
    background-size: cover;
    background-position: center;
}

    .About h2 {
        font-size: 3.5em;
        margin-bottom: 10px;
        color: #fff;
        text-align:center;
    }

    .About div {
        font-size: 1.2rem;
        color: #fff;
    }

.Profile {
    position: relative;
    padding: 100px;
    background: url("https://static.vecteezy.com/system/resources/previews/000/517/088/original/vector-landscape-illustration.png");
    background-size: cover;
    background-position: center;
}

.ContactUs {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    position: relative;
    padding: 100px;
    background: url("https://static.vecteezy.com/system/resources/previews/000/206/269/original/vector-landscape-illustration.jpg");
    background-size: cover;
    background-position: center;
}

    .ContactUs h2 {
        font-size: 3.5em;
        margin-bottom: 10px;
        color: #fff;
        text-align: center;
        padding-bottom: 45px;
        padding-top: 45px;
    }

    .ContactUs .text h3 {
        font-size: 2em;
        margin-bottom: 10px;
        color: black;
    }

    .ContactUs .text p {
        font-size: 1.2em;
        padding: 2px;
    }



.img1 {
    width: 40px;
    height: 40px;
}

.contactInfo {
    display: flex;
    align-items: center;
    justify-content: center;
}

.box {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    background: rgb(255, 255, 255,0.5);
    border-radius: 25px;
    padding: 62px;
    margin: 52px;
    width: 23%;
    text-align: center;
}

/*.box #box1:hover{
    width:25%;
}
    .box #box2:hover {
        width: 25%;
    }
    .box #box3:hover {
        width: 25%;
    }*/
/*Profile*/
.Profile {
}

    .Profile h2 {
        padding:10px;
        font-size: 60px;
        text-align: center;
        color: white;
    }

.Profileimg {
    width: 20%;
    float: left;
    margin-right: 50px;
    width: 200px;
    height: 200px;
    margin-top:5%;
    border-radius:20px;
}

.profilebox table td {
    font-size: 20px;
    color: white;
    font-weight: 300;
    padding-right: 20px; /* Increase the value to add more space */
}

.UploadText {
    color:white;
    font-size:15px;
    margin-top:5px;
    margin-right: 50px;
}
.UploadLabel {
    color: white;
    font-size: 15px;
    margin-top: 5px;
    margin-right: 20px;
}
.FileUpload {
    
    font-size: 15px;
    margin-top: 5px;
    margin-right: 20px;
}
.ProfileInfo {
    padding: 40px;
    display: flex;
    
}
.Profiledisplay {
    display: flex;
    align-items: center;
    justify-content: center;
}

.profilebox {
    display: flex;
    flex-direction: column;
    align-items: center;
    
}

    .profilebox table {
        width: 100%;
        height: 60%;
    }

        .profilebox table td {
            font-size: 20px;
            color: white;
            font-weight: 300;
        }

.textboxreg {
    max-width: 70%;
    width: 80%;
    height: 55px;
    background-color: #f0f0f0;
    margin: 10px 0;
    border-radius: 55px;
    display: grid;
    padding: 0 0.4rem;
    position: relative;
    font-size: 20px;
    border-color: white;
}

.Profilebtn {
    width: 150px;
    height: 49px;
    outline: none;
    border: none;
    border-radius: 48px;
    background-color: white;
    color: dimgrey;
    text-transform: uppercase;
    font-weight: 600;
    margin: 10px ;
    
}

.ProfileButtons {
    display: flex;
    align-items: center;
    justify-content: center;
    margin-left: 14%;
}

.Profilebtn:hover{
    color:black;
}
