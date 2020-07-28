const staticAssets = [
    './',
    './css/demo.min.css',
    './img/logoGGI50px.png'
];

self.addEventListener('install', async event => {
    const cache = await caches.open('static-cache');
    cache.addAll(staticAssets);
    console.log("2. service worker instalado (cache)...")

});


self.addEventListener('fetch', event => {
    console.log("2. service worker instalado (cache)...")

    const req = event.request;
    const url = new URL(req.url);

    if (url.origin === location.url) {
        event.respondWith(cacheFirst(req));
    } else {
        event.respondWith(newtorkFirst(req));
    }
});

//self.addEventListener('fetch', function (event) {
//    console.log(event.request.url);
//    event.respondWith(
//        caches.match(event.request).then(function (response) {
//            return response || fetch(event.request);
//        })
//    );
//});

async function cacheFirst(req) {
    const cachedResponse = caches.match(req);
    return cachedResponse || fetch(req);
}

async function newtorkFirst(req) {
    const cache = await caches.open('dynamic-cache');

    try {
        const res = await fetch(req);
        cache.put(req, res.clone());
        return res;
    } catch (error) {
        return await cache.match(req);
    }
}
