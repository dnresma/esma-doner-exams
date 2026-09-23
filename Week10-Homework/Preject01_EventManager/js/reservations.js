(function ($) {
    'use strict';
    function initRezervations() {
        const rezForm = $("#rez-form");
        const dimensionSelect = $("#dimension");
        const passengerCount = $("#passenger-count");
        const priceDisplay = $("#price-display");
        const riskAlert = $("#risk-alert"); 



        function calculatePriceAndRisk() {
            if (dimensionSelect.val().length === 0 || passengerCount.val().length === 0) {
                return;
            }

            //Fiyat için gerekli dataları alma
            const selectedOption = dimensionSelect.find("option:selected");
            const basePrice = parseInt(selectedOption.data('price') || 0);
            const riskLevel = selectedOption.data('risk') || 'Low';
            const passengers = parseInt(passengerCount.val() || 1);

            //Fiyat hesaplaması
            const total = basePrice * passengers;
            if (total > 0) {
                priceDisplay.text(total.toLocaleString() + "  TL")
            } else {
                priceDisplay.text("(Fiyat bilgisi sorunlu) 0 TL");
            }

            //Eğer tuttar yüksekse risk uyarısı
            if (riskLevel === "High") {
                riskAlert.removeClass("d-none");
                riskAlert.html(`
                <strong>
                    DİKKAT!
                </strong>
                Seçtiğiniz etkinlik yüksek fiyatlıdır. Bilginize!
            `)
            } else {
                riskAlert.addClass("d-none");
            }
        }

        //Etkinlik veya kişi değiştiğinde hesaplama tetiklensin
        dimensionSelect.on('change', calculatePriceAndRisk);
        passengerCount.on('change', calculatePriceAndRisk);

        //Form submit olunca 
        rezForm.on('submit', function (event) {
            event.preventDefault();
            $(this).addClass("was-validated");


            if (this.checkValidity()) {
                 
                const fullName = $("#full-name").val();
                const eventName = $("#dimension option:selected").text();
                const passenger = $("#passenger-count").val();
                const totalPrice = $("#price-display").text();
                 
                $("#card-name").text(fullName);
                $("#card-event").text(eventName);
                $("#card-passenger").text(passenger);
                $("#card-price").text(totalPrice);
                 
                $("#reservation-card").removeClass("d-none");

                this.reset();
                $(this).removeClass("was-validated");
                 
                priceDisplay.text("0 TL");
                riskAlert.addClass("d-none");
                            }

        });
    }
    $(function () {
        initRezervations();
    })

})(jQuery);