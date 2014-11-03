<?php get_header(); ?>
<div id="site_content">
	<?php if(!dynamic_sidebar('content-widgets')): ?>
      <div class="content">
        <h1>Welcome to the CSS3_bokeh template</h1>
        <p>This simple, fixed width website template is released under a <a href="http://creativecommons.org/licenses/by/3.0">Creative Commons Attribution 3.0 Licence</a>. This means you are free to download and use it for personal and commercial projects. However, you <strong>must leave the 'design from css3templates.co.uk' link in the footer of the template</strong>.</p>
        <p>This template is written entirely in <strong>HTML5</strong> and <strong>CSS3</strong>.</p>
        <p>You can view more free CSS3 web templates <a href="http://www.css3templates.co.uk">here</a>.</p>
        <p>This template is a fully documented 5 page website, with an <a href="examples.html">examples</a> page that gives examples of all the styles available with this design. There is also a working PHP contact form on the contact page.</p>
        <h2>Browser Compatibility</h2>
        <p>This template has been tested in the following browsers:</p>
        <ul>
          <li>Internet Explorer 8</li>
          <li>Internet Explorer 7</li>
          <li>FireFox 10</li>
          <li>Google Chrome 17</li>
          <li>Safari 4</li>
        </ul>
      </div>
    </div>
    <div id="scroll">
      <a title="Scroll to the top" class="top" href="#"><img src="images/top.png" alt="top" /></a>
    </div>
<?php get_sidebar(); ?>
<?php get_footer(); ?>