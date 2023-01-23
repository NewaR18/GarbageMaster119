function AppViewModel() {
    var self = this;
    models = {
        Master: function (item) {
            item = item || {};
            this.fname = ko.observable(item.fname || '');
            this.mname = ko.observable(item.mname || '');
            this.lname = ko.observable(item.lname || '');
            this.email = ko.observable(item.email || '');
            this.uname = ko.observable(item.uname || '');
            this.password = ko.observable(item.password || '');
            this.cpassword = ko.observable(item.cpassword || '');
            this.hello = ko.observable(item.hello || '');
            this.terms = ko.observable(item.terms || false);
            this.availables = ko.observableArray(
                [{ name: 'Ward 1', id: 1 },
                { name: 'Ward 2', id: 2 },
                { name: 'Ward 3', id: 3 },
                { name: 'Ward 4', id: 4 },
                { name: 'Ward 5', id: 5 },
                { name: 'Ward 6', id: 6 },
                { name: 'Ward 7', id: 7 },
                { name: 'Ward 8', id: 8 },
                { name: 'Ward 9', id: 9 },
                { name: 'Ward 10', id: 10 },
                { name: 'Ward 11', id: 11 },
                { name: 'Ward 12', id: 12 },
                { name: 'Ward 13', id: 13 },
                { name: 'Ward 14', id: 14 },
                { name: 'Ward 15', id: 15 },
                { name: 'Ward 16', id: 16 },
                { name: 'Ward 17', id: 17 },
                { name: 'Ward 18', id: 18 },
                { name: 'Ward 19', id: 19 },
                { name: 'Ward 20', id: 20 },
                { name: 'Ward 21', id: 21 },
                { name: 'Ward 22', id: 22 },
                { name: 'Ward 23', id: 23 },
                { name: 'Ward 24', id: 24 },
                { name: 'Ward 25', id: 25 },
                { name: 'Ward 26', id: 26 },
                { name: 'Ward 27', id: 27 },
                { name: 'Ward 28', id: 28 },
                { name: 'Ward 29', id: 29 },
                { name: 'Ward 30', id: 30 },
                { name: 'Ward 31', id: 31 },
                { name: 'Ward 32', id: 32 }]
            );
        }
    }
    saveprocess = function () {
        var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
        if (self.Master().fname() == '' || self.Master().fname() == undefined) {
            document.getElementById("errorfname").innerHTML = "**Please enter your first name";
        } else if (self.Master().lname() == '' || self.Master().lname() == undefined) {
            document.getElementById("errorfname").innerHTML = "";
            document.getElementById("errorlname").innerHTML = "**Please enter your last name";
        } else if (self.Master().email() == '' || self.Master().email() == undefined) {
            document.getElementById("errorlname").innerHTML = "";
            document.getElementById("errorfname").innerHTML = "";
            document.getElementById("erroremail").innerHTML = "**Please enter your email address";
        } else if (!self.Master().email().match(mailformat)) {
            document.getElementById("errorlname").innerHTML = "";
            document.getElementById("errorfname").innerHTML = "";
            document.getElementById("erroremail").innerHTML = "**Please enter valid email address";
        } else if (self.Master().uname() == '' || self.Master().uname() == undefined) {
            document.getElementById("errorlname").innerHTML = "";
            document.getElementById("errorfname").innerHTML = "";
            document.getElementById("erroremail").innerHTML = "";
            document.getElementById("errorusername").innerHTML = "**Please enter your username";
        } else if (self.Master().password() == '' || self.Master().password() == undefined) {
            document.getElementById("errorlname").innerHTML = "";
            document.getElementById("errorfname").innerHTML = "";
            document.getElementById("erroremail").innerHTML = "";
            document.getElementById("errorusername").innerHTML = "";
            document.getElementById("errorpassword").innerHTML = "**Please enter your password";
        } else if (self.Master().password().length < 8) {
            document.getElementById("errorlname").innerHTML = "";
            document.getElementById("errorfname").innerHTML = "";
            document.getElementById("erroremail").innerHTML = "";
            document.getElementById("errorusername").innerHTML = "";
            document.getElementById("errorpassword").innerHTML = "**Please enter valid password";
        } else if (self.Master().cpassword() == '' || self.Master().cpassword() == undefined) {
            document.getElementById("errorlname").innerHTML = "";
            document.getElementById("errorfname").innerHTML = "";
            document.getElementById("erroremail").innerHTML = "";
            document.getElementById("errorusername").innerHTML = "";
            document.getElementById("errorpassword").innerHTML = "";
            document.getElementById("errorcpassword").innerHTML = "**Please enter confirm password field";
        } else if (self.Master().password() != self.Master().cpassword()) {
            document.getElementById("errorlname").innerHTML = "";
            document.getElementById("errorfname").innerHTML = "";
            document.getElementById("erroremail").innerHTML = "";
            document.getElementById("errorusername").innerHTML = "";
            document.getElementById("errorpassword").innerHTML = "";
            document.getElementById("errorcpassword").innerHTML = "";
            document.getElementById("errorcpassword").innerHTML = "**Your password and confirm password is not matching";
        } else if (self.Master().hello() == undefined) {
            document.getElementById("errorlname").innerHTML = "";
            document.getElementById("errorfname").innerHTML = "";
            document.getElementById("erroremail").innerHTML = "";
            document.getElementById("errorusername").innerHTML = "";
            document.getElementById("errorpassword").innerHTML = "";
            document.getElementById("errorcpassword").innerHTML = "";
            document.getElementById("errorhello").innerHTML = "**Please enter your ward";
        } else if (self.Master().terms() == false) {
            document.getElementById("errorlname").innerHTML = "";
            document.getElementById("errorfname").innerHTML = "";
            document.getElementById("erroremail").innerHTML = "";
            document.getElementById("errorusername").innerHTML = "";
            document.getElementById("errorpassword").innerHTML = "";
            document.getElementById("errorcpassword").innerHTML = "";
            document.getElementById("errorhello").innerHTML = "";
            document.getElementById("errorterms").innerHTML = "You need to accept our terms and conditions in order to register";
        } else {
            document.getElementById("errorlname").innerHTML = "";
            document.getElementById("errorfname").innerHTML = "";
            document.getElementById("erroremail").innerHTML = "";
            document.getElementById("errorusername").innerHTML = "";
            document.getElementById("errorpassword").innerHTML = "";
            document.getElementById("errorcpassword").innerHTML = "";
            document.getElementById("errorhello").innerHTML = "";
            document.getElementById("errorterms").innerHTML = "";
            $.ajax({
                type: "POST",
                url: "/Main/RegisterUser",
                dataType: "json",
                data: { fname: self.Master().fname(), mname: self.Master().mname(), lname: self.Master().lname(), email: self.Master().email(), uname: self.Master().uname(), password: self.Master().password(), ward: self.Master().hello() },
                success: function (result) {
                    var name = result.Name;
                    if (name == "UserRegistered") {
                        Swal.fire({
                            title: 'Great!',
                            text: 'You are now a member of Garbage Master community!',
                            icon: 'success',
                            showCancelButton: true,
                            confirmButtonColor: '#04736a',
                            cancelButtonColor: '#d33',
                            confirmButtonText: 'Redirect to Login Page'
                        }).then((result) => {
                            if (result.isConfirmed) {
                                window.location = "Login.aspx";
                            }
                        })
                        self.Master().fname("");
                        self.Master().mname("");
                        self.Master().lname("");
                        self.Master().email("");
                        self.Master().uname("");
                        self.Master().password("");
                        self.Master().cpassword("");
                        self.Master().hello("");
                        self.Master().terms("");
                    } else if (name == "EmailExists") {
                        document.getElementById("erroremail").innerHTML = "**This email address is already used. Please try another";
                    } else if (name == "UsernameExists") {
                        document.getElementById("errorusername").innerHTML = "**This username is already used. Please try another";
                        console.log(name)
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Oops...',
                            text: 'Something went wrong!',
                            footer: 'Please try again Later'
                        })
                    }/*
                    self.Master().name("");
                    self.Master().email("");
                    self.Master().subject("");
                    self.Master().message("");*/
                    console.log(result);
                },
                error: function (req, status, error) {
                    console.log(status);
                    console.log(req);
                    console.log(error);
                }
            });
        }
    }
    Init = function () {
        self.Master = ko.observable(new models.Master());
    }
    Init();
}
var obj;
$(document).ready(function () {
    obj = new AppViewModel();
    ko.applyBindings(obj);
});
/*function myFunction() {
    document.getElementById("demo").innerHTML = "Paragraph changed.";
}*/