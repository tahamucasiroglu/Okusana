import React, { useState, useEffect } from 'react';
import sha256 from 'crypto-js/sha256';
import axios from 'axios';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';
import BlogPage from './BlogPage';

const CategoryPage = ({ categoryId, setcategoryId, setsubCategoryId, setBlogId }) => {
    const [blogs, setBlogs] = useState([]);

    useEffect(() => {
        const fetchBlogs = async () => {
            try {
                const response = await axios.get(`https://localhost:7228/api/Blog/GetByCategoryId`,
                    {
                        params: {
                            Value: categoryId
                        },
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    });

                const blogsResponse = response.data.value.data.data;
                setBlogs(blogsResponse);
            } catch (error) {
                console.error('Kategori verileri alınırken hata oluştu:', error);
            }
        };
        fetchBlogs();
    }, [categoryId]);

    const setBlog = (blogId) => { setBlogId(blogId); setcategoryId(null); setsubCategoryId(null); }


    return (
        <div>
            {blogs.map((blog, count) => (
                <Box key={blog.id} sx={{ minWidth: 275 }}>
                    <Card variant="outlined">
                        <CardContent>
                            <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
                                Kullanıcı Id (degisecek ismi gelecek) = {blog.userId}
                            </Typography>
                            <Typography variant="h5" component="div">
                                {blog.title}
                            </Typography>
                            <Typography sx={{ mb: 1.5 }} color="text.secondary">
                                {blog.content.length > 100 ? `${blog.content.substring(0, 100)}...` : blog.content}
                            </Typography>
                        </CardContent>
                        <div className="devaminioku">
                            <button onClick={setBlog(blog.id)}>
                                Devamını Oku
                            </button>
                        </div>
                    </Card>
                </Box>
            ))}
        </div>
    );

    //return (
    //        <div>
    //        {blogs.map((blog, count) => (
    //                <Box key={blog.id} sx={{ minWidth: 275 }}>
    //                    <Card variant="outlined">
    //                        <CardContent>
    //                            <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
    //                                Kullanıcı Id (degisecek ismi gelecek) = {blog.userId}
    //                            </Typography>
    //                            <Typography variant="h5" component="div">
    //                                {blog.title}
    //                            </Typography>
    //                            <Typography sx={{ mb: 1.5 }} color="text.secondary">
    //                                {blog.content.length > 100 ? `${blog.content.substring(0, 100)}...` : blog.content}
    //                            </Typography>
    //                        </CardContent>
    //                        <div className="devaminioku">
    //                        <Link key={blog.id} to={`blog/${count}/*`}>
    //                                Devamını Oku
    //                            </Link>
    //                        </div>
    //                    </Card>
    //                </Box>
    //            ))}
    //        <Routes>
    //            {blogs.map((blog, count) => (
    //                <Route
    //                    key={blog.id}
    //                    path={`blog/${count}/*`}
    //                    element={<BlogPage blog={blog} />}
    //                />
    //            ))}
    //        </Routes>
    //        </div>
    //);
};

export default CategoryPage;
