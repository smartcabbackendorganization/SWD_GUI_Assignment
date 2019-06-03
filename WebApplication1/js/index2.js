// Vue code for the Music page
vm = new Vue({
    el: '#vueApp',
    data: {
        lokations: ["hej", "hej"],
        loading: false
    },
    methods: {
    },
    mounted() {
        // Get all upcomming music arrangements
        fetch('/manage/lokations').then(function (response) {
            if (response.status !== 200) {
                console.log('Looks like there was a problem. Status Code: ' + response.status);
                return;
            }

            response.json().then(function (lokations) {

                console.log("LOL?");
                vm.loading = false;
                console.log(lokations)
                vm.lokations = lokations;
                })
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        });
    }
});