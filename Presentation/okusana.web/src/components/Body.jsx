import React from 'react';
import BlogPage from './BlogPage';
import CategoryPage from './CategoryPage';
import MainPage from './MainPage';
import SubCategoryPage from './SubCategoryPage';

function Body({ categoryId, subCategoryId, setBlogId, blogId, setcategoryId, setsubCategoryId, setSubCategories, subCategories }) {


    if (categoryId === null && subCategoryId === null && blogId === null) {
        return (<MainPage setBlogId={setBlogId} />);
    } else if (blogId !== null) {
        return (<BlogPage blogId={blogId} />);
    }
    else if (subCategoryId !== null) {
        return (<SubCategoryPage subCategoryId={subCategoryId} setcategoryId={setcategoryId} setsubCategoryId={setsubCategoryId} setBlogId={setBlogId} subCategories={subCategories} setSubCategories={setSubCategories} />);
    }
    else if (categoryId !== null) {
        return (<CategoryPage categoryId={categoryId} setcategoryId={setcategoryId} setsubCategoryId={setsubCategoryId} setBlogId={setBlogId} />);
    }
    else {
        return (
            <p>Hello world!</p>
        );
    }
  
}

export default Body;