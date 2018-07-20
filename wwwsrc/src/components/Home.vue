<template>
  <div class = "fullscreen">
    <div class="home container-fluid">
      <div class="main-top-style">

        <!-- Login Modal -->
        <button type="button" class="btn btn1 mt-1 btnwidth2 mr-4" data-toggle="modal" data-target="#loginModal">Login</button>
        <div class="modal fade" id="loginModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Login</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                <form v-on:submit.prevent="userLogin">
                  <div class="form-group">
                    <input type="text" name="username" v-model="
                          login.username" class="form-control" id="formGroupExampleInput" placeholder="Username" required>
                  </div>
                  <div class="form-group">
                    <input type="text" name="password" v-model="
                              login.password" class="form-control" id="formGroupExampleInput" placeholder="Password">
                  </div>
                  <button type="button" @click="userLogin" class="btn btn1" data-dismiss="modal">Login</button>
                  <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                </form>
              </div>
            </div>
          </div>
        </div>

        <!-- Register Modal -->
        <button type="button" class="btn btn1 mt-1 btnwidth2 ml-4" data-toggle="modal" data-target="#registerModal">Register</button>
        <div class="modal fade" id="registerModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Register</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                <form v-on:submit.prevent="userRegister">
                  <div class="form-group">
                    <input type="text" name="username" v-model="register.username" class="form-control" id="formGroupExampleInput" placeholder="Username"
                      required>
                  </div>
                  <div class="form-group">
                    <input type="text" name="email" v-model="register.email" class="form-control" id="formGroupExampleInput" placeholder="email">
                  </div>
                  <div class="form-group">
                    <input type="text" name="password" v-model="register.password" class="form-control" id="formGroupExampleInput" placeholder="Password">
                  </div>
                  <button type="button" @click="userRegister" class="btn btn1" data-dismiss="modal">Register</button>
                  <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                </form>
              </div>
            </div>
          </div>
        </div>

        <h1 class="Title">keepr</h1>
        
      </div>
    </div>
    
  </div>
</template>



<script>
import router from "../router";
import Profile from "./Profile";
import Keep from "./Keep";
export default {
  name: "Home",
  data() {
    return {
      login: {
        username: "",
        password: ""
      },
      register: {
        username: "",
        email: "",
        password: ""
      }
    };
  },
  components: {
    Profile,
    Keep
  },
  mounted() {
    this.$store.dispatch("getKeeps");
    
  },

  computed: {
    user() {
      return this.$store.state.user;
    }
  },

  methods: {
    userLogin() {
      this.$store.dispatch("login", this.login);
    },
    userRegister() {
      this.$store.dispatch("register", this.register);
    },
    getKeeps() {
      this.$store.dispatch("getKeeps", this.user)
    },
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.fullscreen {
  height: 100vh;
}
.main-top-style {
  background-color: rgb(255, 0, 0);
  color: white;
  height: 70vh;
  /* border-bottom: 2px solid black; */
}
.main-bottom-style {
  background-color: rgb(255, 0, 0);
  height: 30vh;
  /* padding: auto; */
}
.Title {
  font-family: "Palanquin Dark", sans-serif;
  color: #fff9e0;
  text-shadow: 2px 2px black;
  padding-top: 4px;
}
.trucklogo {
  border-radius: 10%;
}
.foodtruck {
  margin-top: 3rem;
}
.btnwidth {
  padding: 5% 20% 5% 20%;
}
.btnwidth2 {
  padding: 2% 10% 2% 10%;
}
.spinner {
  color: #fff9e0;
}
</style>