function GoPage(pageName) {
    let searchParams = new URLSearchParams(window.location.search);
    let writerId = searchParams.get('writerId');
    window.location.href = `${pageName}?writerId=${writerId}`;
    //window.location.href = `${pageName}?writerId=10`;
};