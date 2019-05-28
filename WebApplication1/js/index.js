// Vue code for the Music page
vm = new Vue({
    el: '#vueApp',
    data: {
        varroes: ["hej", "hej"],
    },
    methods: {
    },
    mounted() {
        console.log("Hej")
        console.log(model.Navn);

        // Get all upcomming music arrangements
        fetch('/data/GetVarroe').then(function (response) {
            if (response.status !== 200) {
                console.log('Looks like there was a problem. Status Code: ' + response.status);
                return;
            }
            // Build the html
            console.log(response.json)
            response.json().then(function (varroes) {
                    vm.loading = false;
                vm.varroes = ["hej","hej","hej"];
                })
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        });
    }
});