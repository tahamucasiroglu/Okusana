import sha256 from 'crypto-js/sha256';
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import CategoryPage from './CategoryPage';
import SubCategoryPage from './SubCategoryPage';
import BlogPage from './BlogPage';

function Header({ setcategoryId, setsubCategoryId, setBlogId }) {

    const [categories, setCategories] = useState([]);
    const [subCategories, setSubCategories] = useState([]);
    const [showSubCategories, setShowSubCategories] = useState({});

    useEffect(() => {
        const fetchCategories = async () => {
            try {
                const response = await axios.get('https://localhost:7228/api/Category/GetAll');
                setCategories(response.data.value.data.data);
            } catch (error) {
                console.error('Kategori verileri alýnýrken hata oluþtu:', error);
            }
        };

        const fetchSubCategories = async () => {
            try {
                const response = await axios.get('https://localhost:7228/api/SubCategory/GetAll');
                setSubCategories(response.data.value.data.data);
            } catch (error) {
                console.error('Alt kategori verileri alýnýrken hata oluþtu:', error);
            }
        };

        fetchCategories();
        fetchSubCategories();
    }, []);

    const handleMouseEnter = (categoryId) => {
        setShowSubCategories((prev) => ({ ...prev, [categoryId]: true }));
    };

    const handleMouseLeave = (categoryId) => {
        setShowSubCategories((prev) => ({ ...prev, [categoryId]: false }));
    };

    const selectCategory = (categoryId) => { setcategoryId(categoryId); setsubCategoryId(null); setBlogId(null) }
    const selectSubCategory = (categoryId) => { setcategoryId(null); setsubCategoryId(categoryId); setBlogId(null)}

    return (
            <header>
                <div className="App-header">
                    {/*<h1>Kategori Listesi</h1>*/}
                    <div className="categories-container">
                        {categories.map((category, count) => {
                            const categoryId = category.id;
                            const filteredSubCategories = subCategories.filter(
                                (subCategory) => subCategory.categoryId === categoryId
                            );

                            return (
                                <div
                                    className="category"
                                    key={category.id}
                                    onMouseEnter={() => handleMouseEnter(categoryId)}
                                    onMouseLeave={() => handleMouseLeave(categoryId)}
                                >
                                    <span>
                                        <button onClick={selectCategory(category.id)}>
                                            {category.name}
                                        </button>
                                    </span>
                                    {showSubCategories[categoryId] && (
                                        <ul className="sub-categories">
                                            {filteredSubCategories.map((subCategory, subcount) => (
                                                <li key={subCategory.id}>
                                                    <button onClick={selectSubCategory(subCategory.id)}>
                                                        {subCategory.name}
                                                    </button>
                                                </li>
                                            ))}
                                        </ul>
                                    )}
                                </div>
                            );
                        })}
                    </div>
                </div>
            </header>
    );

    //return (
    //    <Router>
    //        <header>
    //            <div className="App-header">
    //                {/*<h1>Kategori Listesi</h1>*/}
    //                <div className= "categories-container">
    //                    {categories.map((category, count) => {
    //                        const categoryId = category.id;
    //                        const filteredSubCategories = subCategories.filter(
    //                            (subCategory) => subCategory.categoryId === categoryId
    //                        );

    //                        return (
    //                            <div
    //                                className="category"
    //                                key={category.id}
    //                                onMouseEnter={() => handleMouseEnter(categoryId)}
    //                                onMouseLeave={() => handleMouseLeave(categoryId)}
    //                            >
    //                                <span>
    //                                    <Link key={category.id} to={`category/${count}/*`}>
    //                                        {category.name}
    //                                    </Link>
    //                                </span>
    //                                {showSubCategories[categoryId] && (
    //                                    <ul className="sub-categories">
    //                                        {filteredSubCategories.map((subCategory, subcount) => (
    //                                            <li key={subCategory.id}>
    //                                                <Link key={category.id} to={`subcategory/${subcount}/*`}>
    //                                                    {subCategory.name}
    //                                                </Link>
    //                                            </li>
    //                                        ))}
    //                                    </ul>
    //                                )}
    //                            </div>
    //                        );
    //                    })}
    //                </div>
    //            </div>
    //        </header>
    //        <Routes>
    //            {categories.map((category, count) => {
    //                const routeProps = {
    //                    key: category.id,
    //                    path: `category/${count}/*`,
    //                    element: <CategoryPage categoryId={category.id} categoryName={category.name} />,
    //                };

    //                return <Route {...routeProps} />;
    //            })}
    //            {subCategories.map((subCategory, subcount) => {
    //                const routeProps = {
    //                    key: subCategory.id,
    //                    path: `subcategory/${subcount}/*`,
    //                    element: <SubCategoryPage subCategoryId={subCategory.id} subCategoryName={subCategory.name} />,
    //                };
    //                return <Route {...routeProps} />;
    //            })}
    //        </Routes>
    //    </Router>
    //);

}

export default Header;