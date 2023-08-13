import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';


function BlogPage({ blogId }) {
    const [blog, setBlog] = useState(null);
    const [user, setUser] = useState(null);

    useEffect(() => {
        const fetchBlog = async () => {
            try {
                const responseBlog = await axios.get(`https://localhost:7228/api/Blog/GetById`,
                    {
                        params: {
                            Value: blogId
                        },
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    });
                setBlog(responseBlog.data.value.data.data);
                const responseUser = await axios.get(`https://localhost:7228/api/User/GetById`,
                    {
                        params: {
                            Value: responseBlog.data.value.data.data.userId
                        },
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    });
                setUser(responseUser.data.value.data.data);
                console.log("blog");
                console.log(responseBlog.data);
                console.log(blog);
                console.log("user");
                console.log(responseUser.data);
                console.log(user);
            } catch (error) {
                console.error('Kategori verileri alınırken hata oluştu:', error);
            }
        };
        fetchBlog();
    }, []);

    return (
        <div className="blog-page">
            {blog === null ? (
                <p>Yükleniyor...</p>
            ) : (
                <div>
                    <h1>{blog.title}</h1>
                    <p>{blog.content}</p>
                    <div className="author-info">
                        {user === null ? (
                            <p>Yazar bilgileri yükleniyor...</p>
                        ) : (
                            <p>Yazar: {user.name} {user.surname}</p>
                        )}
                    </div>
                </div>
            )}
        </div>
    );
}

export default BlogPage;