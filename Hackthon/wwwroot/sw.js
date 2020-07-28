importScripts("https://storage.googleapis.com/workbox-cdn/releases/4.0.0/workbox-sw.js");

importScripts('./db-helpers.js');

if (workbox) {
    console.log("Yay! Aqui sempre funciona!");
    workbox.precaching.precacheAndRoute([]);

    /*  cache images in the e.g others folder; edit to other folders you got
    and config in the sw-config.js file
    */

    workbox.routing.registerRoute(
        new RegExp('/home'),
        new workbox.strategies.NetworkFirst({
            // use a custom cache name
            cacheName: "massacration-doc-cache",
        })
    );

    workbox.routing.registerRoute(
        /(.*)others(.*)\.(?:png|gif|jpg)/,
        new workbox.strategies.CacheFirst({
            cacheName: "images",
            plugins: [
                new workbox.expiration.Plugin({
                    maxEntries: 50,
                    maxAgeSeconds: 30 * 24 * 60 * 60, // 30 Days
                })
            ]
        })
    );


    workbox.routing.registerRoute(
        // cache js, css, scc files
        /.*\.(?:css|js|scss|)/,
        // use cache but update in the background ASAP
        new workbox.strategies.NetworkFirst({
            // use a custom cache name
            cacheName: "ggi-static-cache",
        })
    );

    // cache google fonts
    workbox.routing.registerRoute(
        new RegExp("https://fonts.(?:googleapis|gstatic).com/(.*)"),
        new workbox.strategies.CacheFirst({
            cacheName: "google-fonts",
            plugins: [
                new workbox.cacheableResponse.Plugin({
                    statuses: [0, 200],
                }),
            ],
        })
    );

    // add offline analytics
    //  workbox.googleAnalytics.initialize();

    /* Install a new service worker and have it update
   and control a web page as soon as possible
    */

    workbox.core.skipWaiting();
    workbox.core.clientsClaim();
    self.openDB();

} else {
    console.log("Oops! Quase sempre funciona ");
}
