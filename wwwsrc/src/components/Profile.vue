<template>
    <div>
<!-- ADD KEEP -->
        <div>
         <form @submit.prevent="addKeep">
            <input type="text" name="title" v-model="keep.name" placeholder="Keep Name">
            <input type="text" name="description" v-model="keep.description" placeholder="Description">
            <input type="url" name="img" v-model="keep.img" placeholder="Image">
            <button type="submit">Add Keep</button>
         </form>
      </div>

        
<!-- ADD VAULT -->
        <div>
         <!-- <div v-for="vault in vaults" class="vaults"> -->
            <button @click="vaultSection(vault)">{{vault.name}}</button>
            <button @click="deleteVault(vault)">Delete vault</button>
         </div>
        <!-- </div> -->
    </div>
</template>

<script>
import router from "../router";
export default {
  name: "Profile",
  data() {
    return {
      keep: {
        name: "",
        description: "",
        img: ""
      },
      vault: {
        name: "",
        description: "",
        authorId: ""
      }
    };
  },
  components: {},
  mounted() {
    if (this.$store.state.user.id) {
      this.$store.dispatch("getKeeps");
    }
  },

  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    deleteKeep(keep) {
      this.$store.dispatch("deleteKeep", keep);
    },
    moveKeep(keep) {
      keep.parentId = this.selected;
      this.$store.dispatch("moveKeep", keep);
      this.selected = "";
    },
    addKeep(keep) {
      this.$store.dispatch("addKeep", this.keep);
    },
    deleteVault(vault) {
      this.$store.dispatch("deleteVault", vault);
    },
    addVault(vault) {
      this.$store.dispatch("addVault", this.vault);
    }
  }
};
</script>

<style>
</style>